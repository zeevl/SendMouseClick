using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace SendMouseClick
{
    class Program
    {
        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public enum MouseEventType : int
        {
            LeftDown = 0x02,
            LeftUp = 0x04,
            RightDown = 0x08,
            RightUp = 0x10
        }


        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                while (true)
                {
                    Console.WriteLine("Cursor pos: " + Cursor.Position.X + ", " + Cursor.Position.Y);
                    Thread.Sleep(50);
                }
            }

            int x = Convert.ToInt32(args[0]);
            int y = Convert.ToInt32(args[1]);

            while (true)
            {
                Console.WriteLine("Sending Click: " + DateTime.Now.ToShortTimeString());
                SetCursorPos(x, y);
                mouse_event((int)MouseEventType.LeftDown, x, y, 0, 0);
                mouse_event((int)MouseEventType.LeftUp, x, y, 0, 0);

                Thread.Sleep(30000);
            }
        }
    }
}
