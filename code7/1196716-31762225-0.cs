    private void yourTextbox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
         // Check for 1 & 0
         if ((e.PlatformKeyCode != 48) || (e.PlatformKeyCode != 49) || (e.PlatformKeyCode != 8))
         { e.Handled = true; }
    }
