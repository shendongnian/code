        public static void IESaveFile(string title)
        {
            Thread.Sleep(1000);
            //Get the Internet Explorer window handle using the window title
            var ieWindowHandle = Process.GetProcesses().FirstOrDefault(process => process.MainWindowTitle.Contains(title))?.MainWindowHandle;
            
            var dialogElements = AutomationElement.FromHandle(ieWindowHandle??IntPtr.Zero).FindAll(TreeScope.Children, Condition.TrueCondition);
            foreach (AutomationElement element in dialogElements)
            {
                if (element.Current.ClassName != "Frame Notification Bar") continue;
                var ChildElements = element.FindAll(TreeScope.Children, Condition.TrueCondition);
                
                foreach (AutomationElement ChildElement in ChildElements)
                {
                    // Identify child window with the name Notification Bar or class name DirectUIHWND
                    if (ChildElement.Current.Name != "Notification bar" && ChildElement.Current.ClassName != "DirectUIHWND") continue;
                    var DownloadCtrls = ChildElement.FindAll(TreeScope.Children, Condition.TrueCondition);
                    foreach (AutomationElement ctrlButton in DownloadCtrls)
                        //Now invoke the button click on the 'Save' button
                        if (ctrlButton.Current.Name.ToLower().Equals("save"))
                            ((InvokePattern) ctrlButton.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                }
            }
        }
