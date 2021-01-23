    var p = System.Diagnostics.Process.GetProcessesByName("WINWORD").FirstOrDefault();
    if (p != null)
    {
        var element = AutomationElement.FromHandle(p.MainWindowHandle);
        if (element != null)
        {
            var pattern = element.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            if (pattern != null)
                pattern.SetWindowVisualState(WindowVisualState.Maximized);
        }
    }
