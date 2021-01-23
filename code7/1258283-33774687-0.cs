    private void FrmBase_OnPreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        try
        {
            dynamic item = e.NewFocus;
            item.IsSelected = true;
        }
        catch (Exception ex)
        {
            
        }
    }
