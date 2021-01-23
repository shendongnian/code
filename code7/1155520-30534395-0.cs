        public static IEnumerable<string> GetScreenContents(AutomationElement window)
        {
            var systemButton = window.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "System"));
            var pattern = (ExpandCollapsePattern)systemButton.GetCurrentPattern(ExpandCollapsePattern.Pattern);
            pattern.Expand();
            SendKeys.SendWait("E");
            SendKeys.SendWait("S");
            Thread.Sleep(100);
            pattern.Expand();
            SendKeys.SendWait("E");
            SendKeys.SendWait("Y");
            Thread.Sleep(100);
            var clipText = Clipboard.GetText();
            var screenWidth = 150;
            return Enumerable.Range(0, clipText.Length / screenWidth)
                .Select(i => clipText.Substring(i * screenWidth, screenWidth));
        }
