    public string GetChormeURL(string ProcessName)
            {
                string ret = "";
                Process[] procs = Process.GetProcessesByName(ProcessName);
                foreach (Process proc in procs)
                {
                    // the chrome process must have a window
                    if (proc.MainWindowHandle == IntPtr.Zero)
                    {
                        continue;
                    }
                    //AutomationElement elm = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                    //         new PropertyCondition(AutomationElement.ClassNameProperty, "Chrome_WidgetWin_1"));
                    // find the automation element
                    AutomationElement elm = AutomationElement.FromHandle(proc.MainWindowHandle);
     
                // manually walk through the tree, searching using TreeScope.Descendants is too slow (even if it's more reliable)
                AutomationElement elmUrlBar = null;
                try
                {
                    // walking path found using inspect.exe (Windows SDK) for Chrome 43.0.2357.81 m (currently the latest stable)
                    // Inspect.exe path - C://Program files (X86)/Windows Kits/10/bin/x64
                    var elm1 = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Google Chrome"));
                    if (elm1 == null) { continue; } // not the right chrome.exe
                    var elm2 = TreeWalker.RawViewWalker.GetLastChild(elm1); // I don't know a Condition for this for finding
                    var elm3 = elm2.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
                    var elm4 = TreeWalker.RawViewWalker.GetNextSibling(elm3); // I don't know a Condition for this for finding
                    var elm5 = elm4.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar));
                    var elm6 = elm5.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, ""));
                    elmUrlBar = elm6.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                }
                catch
                {
                    // Chrome has probably changed something, and above walking needs to be modified. :(
                    // put an assertion here or something to make sure you don't miss it
                    continue;
                }
     
                // make sure it's valid
                if (elmUrlBar == null)
                {
                    // it's not..
                    continue;
                }
     
                // elmUrlBar is now the URL bar element. we have to make sure that it's out of keyboard focus if we want to get a valid URL
                if ((bool)elmUrlBar.GetCurrentPropertyValue(AutomationElement.HasKeyboardFocusProperty))
                {
                    continue;
                }
     
                // there might not be a valid pattern to use, so we have to make sure we have one
                AutomationPattern[] patterns = elmUrlBar.GetSupportedPatterns();
                if (patterns.Length == 1)
                {
                    try
                    {
                        ret = ((ValuePattern)elmUrlBar.GetCurrentPattern(patterns[0])).Current.Value;
                        return ret;
                    }
                    catch { }
                    if (ret != "")
                    {
                        // must match a domain name (and possibly "https://" in front)
                        if (Regex.IsMatch(ret, @"^(https:\/\/)?[a-zA-Z0-9\-\.]+(\.[a-zA-Z]{2,4}).*$"))
                        {
                            // prepend http:// to the url, because Chrome hides it if it's not SSL
                            if (!ret.StartsWith("http"))
                            {
                                ret = "http://" + ret;
                            }
                            return ret;
                        }
                    }
                    continue;
                }
            }
            return ret;
        }
