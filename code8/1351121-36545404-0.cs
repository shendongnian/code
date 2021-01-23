        public struct URLDetails
        {
            
            public String URL;
            
            public String Title;
        }
        public static URLDetails[] InternetExplorer()
        {
            Process[] pname = Process.GetProcessesByName("iexplore");
            if (pname.Length == 0) {
                Console.Write("Process is not running ");
            }
            System.Collections.Generic.List<URLDetails> URLs = new System.Collections.Generic.List<URLDetails>();
            var shellWindows = new SHDocVw.ShellWindows();
            foreach (SHDocVw.InternetExplorer ie in shellWindows)
                URLs.Add(new URLDetails() { URL = ie.LocationURL, Title = ie.LocationName });
            return URLs.ToArray();
        }
        public static string GetChromeUrl(Process process)
        {
            if (process == null)
                throw new ArgumentNullException("process");
            if (process.MainWindowHandle == IntPtr.Zero)
                return null;
            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element == null)
                return null;
            AutomationElement edit = element.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            return ((ValuePattern)edit.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            
        }
       
    }
