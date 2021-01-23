    class Program
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        static void Main(string[] args)
        {
            DoSendMessage("Sending a message, a message from me to you");
        }
     
        
        private static void DoSendMessage(string message)
        {
            Process notepad = Process.Start(new ProcessStartInfo("notepad.exe"));
            notepad.WaitForInputIdle();
            
            if (notepad != null)
            {
                IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), "Edit", null);
                SendMessage(child, 0x000C, 0, message);
            }
        }
    }
