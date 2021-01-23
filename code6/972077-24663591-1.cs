    protected void Page_Load(object send, EventArgs e)
    {
        if (!PostBack)
        {
            // ... some unknown code here
        }
        // ... some unknown code here
        (webControl as TextBox).Enabled = false;
    }
