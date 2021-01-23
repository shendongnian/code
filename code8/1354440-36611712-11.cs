    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Form1
    {
        public partial class Form1 : Form
        {
            private int posx, posy;
            private int locx, locy;
            private int curx, cury;
            private Rectangle screenRect;
            private Rectangle rect;
    
            public Form1()
            {
                InitializeComponent();
                codeit();
            }
    
            private void codeit()
            {
    
                locx = this.Location.X; locy = this.Location.Y;
                screenRect = Screen.PrimaryScreen.WorkingArea;
                rect = this.RectangleToScreen(screenRect);
                Console.WriteLine(rect.ToString());
                
                // to avoid clicking outside the window...
                locx += rect.X; locy += rect.Y; // location of window relative to screen
            }
    
            [DllImport("user32.dll")]
            public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
    
            [DllImport("user32")]
            public static extern int SetCursorPos(int x, int y);
    
            [DllImport("USER32.DLL")]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("user32.dll")]
            private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    
            private static bool WindowActive(string keys, IntPtr handle)
            {
                throw new NotImplementedException();
            }
    
            //________________________________________________________________________________________
            // Input Region Begin
            [Flags]
            enum MouseEventFlags : uint
            {
                MOUSEEVENTF_MOVE = 0x0001,
                MOUSEEVENTF_LEFTDOWN = 0x0002,
                MOUSEEVENTF_LEFTUP = 0x0004,
                MOUSEEVENTF_RIGHTDOWN = 0x0008,
                MOUSEEVENTF_RIGHTUP = 0x0010,
                MOUSEEVENTF_MIDDLEDOWN = 0x0020,
                MOUSEEVENTF_MIDDLEUP = 0x0040,
                MOUSEEVENTF_XDOWN = 0x0080,
                MOUSEEVENTF_XUP = 0x0100,
                MOUSEEVENTF_WHEEL = 0x0800,
                MOUSEEVENTF_VIRTUALDESK = 0x4000,
                MOUSEEVENTF_ABSOLUTE = 0x8000
            }
    
            ///// <summary>
            ///// Synthesizes keystrokes, mouse motions, and button clicks.
            ///// </summary>
            [DllImport("user32.dll", SetLastError = true)]
            static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);
    
            // INPUT
            [StructLayout(LayoutKind.Sequential)]
            struct INPUT
            {
                public SendInputEventType type;
                public MouseKeybdhardwareInputUnion mkhi; // Mouse, Keyboard, Hardware, Input
            }
    
            enum SendInputEventType : int
            {
                MOUSE = 0,
                KEYBOARD = 1,
                HARDWARE = 2
            }
    
            [StructLayout(LayoutKind.Explicit)]
            struct MouseKeybdhardwareInputUnion
            {
                [FieldOffset(0)]
                public MouseInputData mi; // mouse input
    
                [FieldOffset(0)]
                public KEYBDINPUT ki; // keyboard input
    
                [FieldOffset(0)]
                public HARDWAREINPUT hi; // hardware input
            }
    
            struct MouseInputData
            {
                public int dx;
                public int dy;
                public uint mouseData;
                public MouseEventFlags dwFlags;
                public uint time;
                public IntPtr dwExtraInfo;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct KEYBDINPUT
            {
                public ushort wVk;
                public ushort wScan;
                public uint dwFlags;
                public uint time;
                public IntPtr dwExtraInfo;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct HARDWAREINPUT
            {
                public int uMsg;
                public short wParamL;
                public short wParamH;
            }
    
            //________________________________________________________________________________________
            // Input Region End
    
    
            // #############################################################################
            // MOUSE INPUT 
            // #############################################################################
            public static void ClickLeftMouseButton() // left click
            {
                INPUT mouseDownInput = new INPUT();
                mouseDownInput.type = SendInputEventType.MOUSE;
                mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
                SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));
    
                /*
                 * NOTE***
                 * Since I have now gotten to this point, I have not done a mouse move yet, but I  believe you
                 * might need to your movement to dx,dy like so:
                 */
                mouseDownInput.mkhi.mi.dx -= 50;
                mouseDownInput.mkhi.mi.dy -= 80;
                /*
                 * ...or apply it's coordinates to the mouse, like this
                 */
                //mouseDownInput.mkhi.mi.dx = Cursor.Position.X;
                //mouseDownInput.mkhi.mi.dy = Cursor.Position.Y;
    
                Console.WriteLine(mouseDownInput.mkhi.mi.dx + "," + mouseDownInput.mkhi.mi.dy +
                    " | " + mouseDownInput.mkhi.mi.mouseData + " | " + mouseDownInput.mkhi.mi.time);
    
                INPUT mouseUpInput = new INPUT();
                mouseUpInput.type = SendInputEventType.MOUSE;
                mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP;
                SendInput(1, ref mouseUpInput, Marshal.SizeOf(new INPUT()));
            }
    
            public static void ClickRightMouseButton() // right click
            {
                INPUT mouseDownInput = new INPUT();
                mouseDownInput.type = SendInputEventType.MOUSE;
                mouseDownInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_RIGHTDOWN;
                SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));
    
                INPUT mouseUpInput = new INPUT();
                mouseUpInput.type = SendInputEventType.MOUSE;
                mouseUpInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_RIGHTUP;
                SendInput(1, ref mouseUpInput, Marshal.SizeOf(new INPUT()));
            }
    
            /// <summary>
            /// checks for the currently active window then simulates a mouseclick
            /// </summary>
            /// <param name="button">which button to press (left middle up)</param>
            /// <param name="windowName">the window to send to</param>
            public static void MouseClick(string button, string windowName)
            {
                switch (button)
                {
                    case "left":
                        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        break;
                    case "right":
                        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                        break;
                    case "middle":
                        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                        mouse_event((uint)MouseEventFlags.MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
                        break;
                }
            }
    
            // #############################################################################
            // OTHER
            // #############################################################################
            /// <summary>
            /// moves a window and resizes it accordingly
            /// </summary>
            /// <param name="x">x position to move to</param>
            /// <param name="y">y position to move to</param>
            /// <param name="windowName">the window to move</param>
            /// <param name="width">the window's new width</param>
            /// <param name="height">the window's new height</param>
            public static void WindowMove(int x, int y, string windowName, int width, int height)
            {
                IntPtr window = FindWindow(null, windowName);
                if (window != IntPtr.Zero) { MoveWindow(window, x, y, width, height, true); }
            }
    
            ///// <summary>
            ///// moves a window to a specified position
            ///// </summary>
            ///// <param name="x">x position</param>
            ///// <param name="y">y position</param>
            ///// <param name="windowName">the window to be moved</param>
            //public static void WindowMove(int x, int y, string windowName)
            //{
            //    WindowMove(x, y, windowName, 800, 600);
            //}
    
            public static void LeftClick(int x, int y)
            {
                Cursor.Position = new System.Drawing.Point(x, y);
                mouse_event((int)(MouseEventFlags.MOUSEEVENTF_LEFTDOWN), x, y, 0, 0);
                mouse_event((int)(MouseEventFlags.MOUSEEVENTF_LEFTUP), x, y, 0, 0);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                posx = 200; posy = 200;
                curx = 100; cury = 100;
                WindowMove(posx, posy, "Form1", 400, 400);
                locx += posx; locy += posy;
                Console.WriteLine(locx + "," + locy);
                SetCursorPos(locx + curx, locy + cury);
                MouseClick("left", "Form1");
                int count = 0; bool rmove = true; 
                int winMaxX = locx + this.Width;
                int winMinX = locx;
                Console.WriteLine("size: " + winMinX + "," + winMaxX);
                do
                {
                    SetCursorPos(locx, locy);
                    if (locx < winMaxX - 10 && rmove) { locx += 1; Thread.Sleep(1); }
                    else 
                    {
                        rmove = false; //count += 1; locx -= 1;
                        if (locx > winMinX + 10 && !rmove) { locx -= 1; Thread.Sleep(1); }
                        else { rmove = true; count += 1; }
                        SetCursorPos(locx, locy);
                    }
    
                    //Cursor.Position = new Point(locx, locy);
                }
                while (count < 5);
                //LeftClick(350, 150); // your function
                MouseClick("right", "Form1");
            }
        }
    }
