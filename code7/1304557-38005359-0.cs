    public UWPBox() : base()
    {
        this.KeyDown += this.KeyDownHandler;
    }
    public virtual async void KeyDownHandler(object sender, KeyRoutedEventArgs e)
    {
        bool isCtrlDown = Window.Current.CoreWindow.GetKeyState(VirtualKey.Control)
            .HasFlag(CoreVirtualKeyStates.Down);
        try
        {
            switch (e.OriginalKey)
            {
                case VirtualKey.I:
                    // First, kill the default "Ctrl-I inserts a tab" action.
                    if (isCtrlDown)
                    {
                        e.Handled = true;
                        this.HandleCtrlI(); // Just in case we want to do 
                                            // something different with Ctrl-I
                    }
                    break;
                // "Fixes" for Ctrl-V and Tab removed.
                // Fuller solution here: https://github.com/ruffin--/UWPBox
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " 
                + ex.Message);
        }
    }
    public virtual void HandleCtrlI()
    {
        System.Diagnostics.Debug.WriteLine("Ctrl-I pressed.");
    }
