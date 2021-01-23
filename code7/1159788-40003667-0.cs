        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string className, string windowTitle);
        public static void IeDownLoadSaveAs(string windowTitle = null)
        {
            if (windowTitle == null)
                windowTitle = "https://web.tdclms.com/lmsweb/TranDotCom.Asp - Internet Explorer";
            //get the message handle
            //the last param "Untitled...is the title of the window and it must match
            IntPtr parentHandle = WindowHandleInfo.FindWindow("IEFrame", windowTitle);
            var parentElements = AutomationElement.FromHandle(parentHandle).FindAll(TreeScope.Children, Condition.TrueCondition);
            foreach (AutomationElement parentElement in parentElements)
            {
                // Identidfy Download Manager Window in Internet Explorer
                if (parentElement.Current.ClassName == "Frame Notification Bar")
                {
                    var childElements = parentElement.FindAll(TreeScope.Children, Condition.TrueCondition);
                    // Idenfify child window with the name Notification Bar or class name as DirectUIHWND 
                    foreach (AutomationElement childElement in childElements)
                    {
                        if (childElement.Current.Name == "Notification bar" || childElement.Current.ClassName == "DirectUIHWND")
                        {
                            var downloadCtrls = childElement.FindAll(TreeScope.Descendants, Condition.TrueCondition);
                            foreach (AutomationElement ctrlButton in downloadCtrls)
                            {
                                //Now invoke the button click whichever you wish
                                if (ctrlButton.Current.Name.ToLower() == "")
                                {
                                    var saveSubMenu = ctrlButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                                    saveSubMenu.Invoke();
                                    var saveMenuHandle = WindowHandleInfo.FindWindow("#32768", "");
                                    var subMenuItems = AutomationElement.FromHandle(saveMenuHandle).FindAll(TreeScope.Children, Condition.TrueCondition);
                                    foreach (AutomationElement item in subMenuItems)
                                    {
                                        if (item.Current.Name.ToLower() == "save as")
                                        {
                                            var saveAsMenuItem = item.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                                            saveAsMenuItem.Invoke();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
