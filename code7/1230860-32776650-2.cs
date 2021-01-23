    private void OnButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        button.Text = "Disabled";
        button.Enabled = false;
    }
