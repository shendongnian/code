    class Program
    {
        static void Main(string[] args)    
        {
            // start our own notepad from scratch
            Process process = Process.Start("notepad.exe");
            // wait for main window to appear
            while(process.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(100);
                process.Refresh();
            }
            var window = AutomationElement.FromHandle(process.MainWindowHandle);
            Console.WriteLine("window: " + window.Current.Name);
    
            // note: carefully choose the tree scope for perf reasons
            // try to avoid SubTree although it seems easier...
            var titleBar = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TitleBar));
            Console.WriteLine("titleBar: " + titleBar.Current.Name);
        }
    }
