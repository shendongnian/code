    private AutomationElement _watchedElement;
    private void PopupOpenedHandler(Object sender, AutomationEventArgs args) {
        var element = sender as AutomationElement;
        if (element == null || !element.Current.ClassName.Equals(MESSAGEBOX_CLASS_NAME)) {
            return;
        }
        object pattern;
        if (!element.TryGetCurrentPattern(WindowPattern.Pattern, out pattern)) return;
        WindowPattern window = (WindowPattern)pattern;
        if (window.Current.WindowInteractionState == WindowInteractionState.ReadyForUserInteraction) {
            window.Close();
        }
    }
    internal bool Hook() {
        Process p = Process.GetProcessById(_processId);
        IntPtr wHnd = p.MainWindowHandle;
        if (wHnd != IntPtr.Zero) {
            _watchedElement = AutomationElement.FromHandle(wHnd);
            Automation.AddAutomationEventHandler (
                WindowPattern.WindowOpenedEvent,
                _watchedElement,
                TreeScope.Descendants,
                PopupOpenedHandler
            );
            return true;
        }
        return false;
    }
    
    internal bool Unhook() {
        if (_watchedElement == null) return false;
        Automation.RemoveAutomationEventHandler(WindowPattern.WindowOpenedEvent, _watchedElement, PopupOpenedHandler);
        return true;
    }
