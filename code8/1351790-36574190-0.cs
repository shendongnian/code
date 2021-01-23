     public void WithSendkeys()
        {
            AutomationElement.RootElement
                .FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Chrome_WidgetWin_1"))
                .SetFocus();
            SendKeys.SendWait("^l");
            var elmUrlBar = AutomationElement.FocusedElement;
            var valuePattern = (ValuePattern) elmUrlBar.GetCurrentPattern(ValuePattern.Pattern);
            Console.WriteLine(valuePattern.Current.Value);
        }
