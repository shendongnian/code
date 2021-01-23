    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("Chrome.exe").WaitForInputIdle();
            var handle = Process.GetCurrentProcess().MainWindowHandle;
            SetForegroundWindow(handle.ToInt32());
            Console.ReadLine();
        }
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd); 
    }
