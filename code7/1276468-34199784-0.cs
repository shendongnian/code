     class Program
        {
            private const int MF_BYCOMMAND = 0x00000000;
            public const int SC_CLOSE = 0xF060;
            public const int SC_MINIMIZE = 0xF020;
            public const int SC_MAXIMIZE = 0xF030;
            [DllImport("user32.dll")]
            public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
            [DllImport("user32.dll")]
            private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
            [DllImport("kernel32.dll", ExactSpelling = true)]
            private static extern IntPtr GetConsoleWindow();
            static void Main(string[] args)
            {
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
                Console.Read();
            }
        }
