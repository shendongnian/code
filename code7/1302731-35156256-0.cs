    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Automation;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Automation = System.Windows.Automation;
    namespace testNS
    {
    public class UIAutomation
    {
        private AutomationElement _currentScope = null;
        public UIAutomation(int hwnd)
        {
            if (_currentScope == null)
                _currentScope = AutomationElement.FromHandle((IntPtr)hwnd);
            Automation.Automation.AddAutomationEventHandler(Automation.WindowPattern.WindowOpenedEvent,
            _currentScope, TreeScope.Subtree, this.handleWindowEvents);
        }
        public void handleWindowEvents(object src, Automation.AutomationEventArgs e)
        {
            try
            {
                AutomationElement aeSrc = src as AutomationElement;
                if (aeSrc.Current.Name.Contains("Visual Basic"))
                {
                   Int32? parentWindowHandle = (_currentScope.GetCurrentPropertyValue(AutomationElement.NativeWindowHandleProperty) as Int32?);
                    if (parentWindowHandle != null && parentWindowHandle > 0)
                    {
                        IntPtr ptrHandle = (IntPtr) parentWindowHandle;
                        //NativeMethods.ShowWindow(ptrHandle, 1);
                    }
                    AutomationElementCollection childrenAutomationElementCollection = aeSrc.FindAll(TreeScope.Children, Condition.TrueCondition);
                    foreach (AutomationElement aeChildren in childrenAutomationElementCollection)
                    {
                        if (aeChildren.Current.Name.Length > 10)
                            Console.WriteLine(aeChildren.Current.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void unregister()
        {
            if (_currentScope != null)
            {
                Automation.Automation.RemoveAutomationEventHandler(Automation.WindowPattern.WindowOpenedEvent, _currentScope, this.handleWindowEvents);
            }
        }
    }
    }
