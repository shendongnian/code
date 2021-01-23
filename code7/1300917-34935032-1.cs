    using Microsoft.Test.Input;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Automation;
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("user32.dll")]
            static extern bool SetForegroundWindow(IntPtr hWnd);
            static void Main(string[] args)
            {
            Process[] localByName = Process.GetProcessesByName("notepad");
            foreach (Process p in localByName)
            {
                string fileName = p.MainWindowTitle; // get file name from notepad title
                SetForegroundWindow(p.MainWindowHandle);
                AutomationElement windowAutomationElement = AutomationElement.FromHandle(p.MainWindowHandle);
                var menuElements = windowAutomationElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
                AutomationElement fileMenuElement = null;
                foreach (AutomationElement element in menuElements)
                {
                    if (element.Current.Name == "File")
                    {
                        fileMenuElement = element;
                        break;
                    }
                }
                if (fileMenuElement != null)
                {
                    fileMenuElement.SetFocus();
                    fileMenuElement.Click();
                    Thread.Sleep(800); // Sleeping an arbitrary amount here since we must wait for the file menu to appear before the next line can find the menuItems. A better way to handle it is probably to run the FindAll in the next line in a loop that breaks when menuElements is no longer null.
                    menuElements = fileMenuElement.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
                    var saveAsMenuElement = fileMenuElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Save As..."));
                    if (saveAsMenuElement != null)
                    {
                        saveAsMenuElement.SetFocus();
                        saveAsMenuElement.Click();
                        Thread.Sleep(800);
                        var saveAsWindow = windowAutomationElement.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
                        var toolbarElements = saveAsWindow.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ToolBar));
                        foreach (AutomationElement element in toolbarElements)
                            if (element.Current.Name.StartsWith("Address:"))
                                Console.WriteLine(element.Current.Name + @"\" + fileName); // Parse out the file name from this concatenation here!
                        var closeButtonElement = saveAsWindow.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Close"));
                        closeButtonElement.Click();
                    }
                }
            }
            Console.ReadLine();
        }
    }
    public static class AutomationElementExtensions
    {
        public static void MoveTo(this AutomationElement automationElement)
        {
            Point somePoint;
            if (automationElement.TryGetClickablePoint(out somePoint))
                Mouse.MoveTo(new System.Drawing.Point((int)somePoint.X, (int)somePoint.Y));
        }
        public static void Click(this AutomationElement automationElement)
        {
            automationElement.MoveTo();
            Mouse.Click(MouseButton.Left);
        }
    }
    }
