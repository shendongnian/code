    private void Radio_CheckedChanged(object sender, EventArgs e)
    {
    var selectedMenuButton = (RadioButton)sender;
    if (selectedMenuButton.Checked)
    {
        if(MenuButtonClickCallback != null)
            MenuButtonClickCallback(parameter);
    }
    }
