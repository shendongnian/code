    public enum AppCommand {
        VolumeDown = 9
        VolumeUp = 10,
        // etc..
    }
    
    private void SendAppCommand(AppCommand cmd) {
        var hwnd = new WindowInteropHelper(this).Handle;
        SendMessageW(hwnd, WM_APPCOMMAND, hwnd, (int)cmd << 16);
    }
