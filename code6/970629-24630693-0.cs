    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;
        }
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);
        static void Main(string[] args)
        {
            ConsoleKey key;
            MousePoint point;
            while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape)
            {
                GetCursorPos(out point);
                if (key == ConsoleKey.LeftArrow)
                    point.X -= 10;
                if (key == ConsoleKey.RightArrow)
                    point.X += 10;
                if (key == ConsoleKey.UpArrow)
                    point.Y -= 10;
                if (key == ConsoleKey.DownArrow)
                    point.Y += 10;
                SetCursorPos(point.X, point.Y);
            }
        }
    }
