    private void Button_MouseMove(object sender, MouseEventArgs e)
    {
        popup.IsOpen = true;
    }
    private void Popup_OnClosed(object sender, EventArgs e)
    {
        if (popup.IsOpen)
            popup.IsOpen = false;
    }
