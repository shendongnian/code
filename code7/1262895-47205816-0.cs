    private void txt_TextChanged(object sender, EventArgs e)
    {
        if (!((TextBox)sender).Focused)
            DoWork();
    }
    
    private void txt_Leave(object sender, EventArgs e)
    {
        DoWork();
    }
