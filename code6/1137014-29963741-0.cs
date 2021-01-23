    class Program
    {
        static void Main(string[] args)
        {
            // this presumes notepad++ has been started somehow
            Process process = Process.GetProcessesByName("notepad++").FirstOrDefault();
            if (process == null)
            {
                Console.WriteLine("Cannot find any notepad++ process.");
                return;
            }
            AutomateNpp(process.MainWindowHandle);
        }
        static void AutomateNpp(IntPtr handle)
        {
            // get main window handle
            AutomationElement window = AutomationElement.FromHandle(handle);
            // display the title
            Console.WriteLine("Title: " + window.Current.Name);
            // open two arbitrary files (change this!)
            OpenFile(window, @"d:\my path\file1.txt");
            OpenFile(window, @"d:\my path\file2.txt");
            // selects all tabs in sequence for demo purposes
            // note the user can interact with n++ (for example close tabs) while all this is working
            while (true)
            {
                var tabs = GetTabsNames(window);
                if (tabs.Count == 0)
                {
                    Console.WriteLine("notepad++ process seems to have gone.");
                    return;
                }
                for (int i = 0; i < tabs.Count; i++)
                {
                    Console.WriteLine("Selecting tab:" + tabs[i]);
                    SelectTab(window, tabs[i]);
                    Thread.Sleep(1000);
                }
            }
        }
        static IList<string> GetTabsNames(AutomationElement window)
        {
            List<string> list = new List<string>();
            // get tab bar
            var tab = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab));
            if (tab != null)
            {
                foreach (var item in tab.FindAll(TreeScope.Children, PropertyCondition.TrueCondition).OfType<AutomationElement>())
                {
                    list.Add(item.Current.Name);
                }
            }
            return list;
        }
        static void SelectTab(AutomationElement window, string name)
        {
            // get tab bar
            var tab = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tab));
            // get tab
            var item = tab.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, name));
            if (item == null)
            {
                Console.WriteLine("Tab item '" + name + "' has been closed.");
                return;
            }
            // select it
            ((SelectionItemPattern)item.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
        }
        static void OpenFile(AutomationElement window, string filePath)
        {
            // get menu bar
            var menu = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuBar));
            // get the "file" menu
            var fileMenu = menu.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "File"));
            // open it
            SafeExpand(fileMenu);
            // get the new File menu that appears (this is quite specific to n++)
            var subFileMenu = fileMenu.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu));
            // get the "open" menu
            var openMenu = subFileMenu.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Open..."));
            // click it
            ((InvokePattern)openMenu.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
            // get the new Open dialog (from root)
            var openDialog = WaitForDialog(window);
            // get the combobox
            var cb = openDialog.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ComboBox));
            // fill the filename
            ((ValuePattern)cb.GetCurrentPattern(ValuePattern.Pattern)).SetValue(filePath);
            // get the open button
            var openButton = openDialog.FindFirst(TreeScope.Children, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.NameProperty, "Open")));
            // press it
            ((InvokePattern)openButton.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
        }
        static AutomationElement WaitForDialog(AutomationElement element)
        {
            // note: this should be improved for error checking (timeouts, etc.)
            while(true)
            {
                var openDialog = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
                if (openDialog != null)
                    return openDialog;
            }
        }
        static void SafeExpand(AutomationElement element)
        {
            // for some reason, menus in np++ behave badly
            while (true)
            {
                try
                {
                    ((ExpandCollapsePattern)element.GetCurrentPattern(ExpandCollapsePattern.Pattern)).Expand();
                    return;
                }
                catch
                {
                }
            }
        }
    }
    
