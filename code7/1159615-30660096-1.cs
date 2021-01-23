    using System.Threading;
    using System.Windows.Automation;
    using WatiN.Core;
    using WatiN.Core.Native.Windows;
    namespace TestFramework.Util
    {
      public static class WindowsHelper
      {
        #region Public Methods
        /// <summary>
        /// Download IE file.
        /// </summary>        
        /// <param name="action">Action can be Save/Save As/Open/Cancel.</param>
        /// <param name="path">Path where file needs to be saved (for Save As function).</param>
        public static void DownloadIEFile(string action, string path = "", string regexPatternToMatch = "")
        {
            Browser browser = null;
            if (Utility.Browser != null) // Utility.Browser is my WatiN browser instance.
            {
                if (string.IsNullOrEmpty(regexPatternToMatch))
                {
                    browser = Utility.Browser;
                }
                else
                {
                    Utility.Wait(() => (browser = Browser.AttachTo<IE>(Find.ByUrl(new System.Text.RegularExpressions.Regex(regexPatternToMatch)))) != null);
                }
            }
            else
            {                
                return;
            }
            // If doesn't work try to increase sleep interval or write your own waitUntill method
            Thread.Sleep(3000);
            // See information here (http://msdn.microsoft.com/en-us/library/windows/desktop/ms633515(v=vs.85).aspx)
            Window windowMain = null;
            Utility.Wait(() => (windowMain = new Window(NativeMethods.GetWindow(browser.hWnd, 5))).ProcessID != 0);
            TreeWalker trw = new TreeWalker(Condition.TrueCondition);
            AutomationElement mainWindow = trw.GetParent(AutomationElement.FromHandle(browser.hWnd));
            Window windowDialog = null;
            Utility.Wait(() => (windowDialog = new Window(NativeMethods.GetWindow(windowMain.Hwnd, 5))).ProcessID != 0);
            windowDialog.SetActivate();
            AutomationElementCollection amc = null;
            Utility.Wait(() => (amc = AutomationElement.FromHandle(windowDialog.Hwnd).FindAll(TreeScope.Children, Condition.TrueCondition)).Count > 1);
            foreach (AutomationElement element in amc)
            {
                // You can use "Save ", "Open", ''Cancel', or "Close" to find necessary button Or write your own enum
                if (element.Current.Name.Equals(action))
                {
                    // If doesn't work try to increase sleep interval or write your own waitUntil method
                    // WaitUntilButtonExsist(element,100);
                    Thread.Sleep(1000);
                    AutomationPattern[] pats = element.GetSupportedPatterns();
                    // Replace this for each if you need 'Save as' with code bellow
                    foreach (AutomationPattern pat in pats)
                    {
                        // '10000' button click event id 
                        if (pat.Id == 10000)
                        {
                            InvokePattern click = (InvokePattern)element.GetCurrentPattern(pat);
                            click.Invoke();
                        }
                    }
                }
                else if (element.Current.Name.Equals("Save") && action == "Save As")
                {
                    AutomationElementCollection bmc = element.FindAll(TreeScope.Children, Automation.ControlViewCondition);
                    InvokePattern click1 = (InvokePattern)bmc[0].GetCurrentPattern(AutomationPattern.LookupById(10000));
                    click1.Invoke();
                    Thread.Sleep(1000);
                    AutomationElementCollection main = mainWindow.FindAll(TreeScope.Children, Condition.TrueCondition);
                    foreach (AutomationElement el in main)
                    {
                        if (el.Current.LocalizedControlType == "menu")
                        {
                            // First array element 'Save', second array element 'Save as', third second array element   'Save and open'
                            InvokePattern clickMenu = (InvokePattern)
                                        el.FindAll(TreeScope.Children, Condition.TrueCondition)[1].GetCurrentPattern(AutomationPattern.LookupById(10000));
                            clickMenu.Invoke();
                            Thread.Sleep(1000);
                            ControlSaveDialog(mainWindow, path);
                            break;
                        }
                    }
                }
            }
        }
     
        /// <summary>
        /// Control for save dialog.
        /// </summary>
        /// <param name="mainWindow">Main window.</param>
        /// <param name="path">Path.</param>
        private static void ControlSaveDialog(AutomationElement mainWindow, string path)
        {
            // Obtain the save as dialog
            var saveAsDialog = mainWindow
                                .FindFirst(TreeScope.Descendants,
                                           new PropertyCondition(AutomationElement.NameProperty, "Save As"));
            // Get the file name box
            var saveAsText = saveAsDialog
                    .FindFirst(TreeScope.Descendants,
                               new AndCondition(
                                   new PropertyCondition(AutomationElement.NameProperty, "File name:"),
                                   new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)))
                    .GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            // Fill the filename box 
            saveAsText.SetValue(path);
            Thread.Sleep(500);
            Utility.PressKey("LEFT");
            Utility.PressKey("LEFT");
            Thread.Sleep(1000);
            // Find the save button
            var saveButton =
                    saveAsDialog.FindFirst(TreeScope.Descendants,
                    new AndCondition(
                        new PropertyCondition(AutomationElement.NameProperty, "Save"),
                        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)));
            // Invoke the button
            var pattern = saveButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            pattern.Invoke();
        }
        #endregion
    }
    }
    public static class Utility
    {       
        public static IE Browser { get; set; }
               
        // Wait specified number of seconds
        public static void Wait(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
        // Wait for condition to evaluate true, timeout after 30 seconds
        public static void Wait(Func<bool> condition)
        {
            int count = 0;
            while (!condition() && count < 30)
            {
                System.Threading.Thread.Sleep(1000);
                count++;
            }
        }
        //Send tab key press to browser
        public static void PressTab()
        {
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            System.Threading.Thread.Sleep(300);
        }
        //Send specified key press to browser
        public static void PressKey(string keyname)
        {
            System.Windows.Forms.SendKeys.SendWait("{" + keyname.ToUpper() + "}");
            System.Threading.Thread.Sleep(300);
        }
       
    }
