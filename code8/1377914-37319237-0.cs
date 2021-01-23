    void LoseFocus(Control control) {
        var isTabStop = control.IsTabStop;
        control.IsTabStop = false;
        control.IsEnabled = false;
        control.IsEnabled = true;
        control.IsTabStop = isTabStop;
    }
