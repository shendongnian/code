    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (Control control in Page.Controls)
        {
            if (control is Button)
            {
                ((Button)control).Text = string.Empty;
            }
        }
    }
