    using System.Windows.Automation;
    using UIAutomationClient;    
    String TextUnderCursor()
        {
            System.Windows.Point point = new System.Windows.Point(Cursor.Position.X, Cursor.Position.Y);
            AutomationElement element = AutomationElement.FromPoint(point);
            object patternObj;
            if (element.TryGetCurrentPattern(TextPattern.Pattern, out patternObj))
            {
                var textPattern = (TextPattern)patternObj;
                return textPattern.DocumentRange.GetText(-1).TrimEnd('\r'); // often there is an extra '\r' hanging off the end.)
            } else
            {
                return "no text found";
            }
        }
