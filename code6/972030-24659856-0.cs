    protected void Button1_Click(object sender, EventArgs e)
    {
        ((Button)sender).Visible = true;
        // or more generally:
        ((WebControl)sender).Visible = true;
    }
