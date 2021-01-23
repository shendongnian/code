    EventManager.RegisterClassHandler(typeof(System.Windows.Controls.TextBox), System.Windows.Controls.TextBox.GotKeyboardFocusEvent, new KeyboardFocusChangedEventHandler(OnGotKeyboardFocus));
    
    void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        var textBox = sender as System.Windows.Controls.TextBox;
        if (textBox != null && !textBox.IsReadOnly && e.KeyboardDevice.IsKeyDown(Key.Tab))
            textBox.SelectAll();
    }
