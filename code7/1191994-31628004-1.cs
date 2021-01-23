    class Program
    {
        static void Main(string[] args)
        {
            var handle = Process.GetCurrentProcess().MainWindowHandle;
            Process.Start("Chrome.exe").WaitForInputIdle();
            SetForegroundWindow(handle.ToInt32());
            Console.ReadLine();
        }
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd); 
    }
