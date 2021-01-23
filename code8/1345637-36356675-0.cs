    Process[] chromeProcesses = Process.GetProcessesByName("chrome");
            if(chromeProcesses.Length > 0)
            {
                foreach(Process proc in chromeProcesses)
                {
                    if (proc.MainWindowHandle == IntPtr.Zero)
                    {
                        continue;
                    }
                    
                    AutomationElement chrome = AutomationElement.FromHandle(proc.MainWindowHandle);
              
                    var tabs = chrome.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem));
                    if (tabs != null)
                    {
                        foreach(AutomationElement tab in tabs)
                        {
                            string tabTitle = tab.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
                            
                            AutomationElement next = tab.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));
                            if (next != null)
                            {
                                string nextContent = next.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
                                if(nextContent != "")
                                {
                                    break;
                                }
                            }
                            if (tabTitle.LastIndexOf(YoutubeRecogPattern, StringComparison.OrdinalIgnoreCase) > 0)
                            {
                                if (tabTitle != this.LastTitle)
                                {
                                    string videoTitle = tabTitle.Substring(0, tabTitle.Length - YoutubeRecogPattern.Length);
    // ...
