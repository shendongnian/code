    private void ClickedButton(object sender, EventArgs e)        
    {
        Button button_send = (Button)sender;
        var value = string.Empty;
        if (button_send.Tag != null && int.TryParse(button_send.Tag.ToString(), out value)
        {
            // check int 'value' against whatever logic you need
        }
    }
