    private void OnClick(object sender, EventArgs e)
    {
        if( sender is Button )
        {
            Button button = (Button)sender;
            button.Enabled = false;
        }
    }
