    protected void Page_Load(object sender, EventArgs e)
    {
        Page1 source = PreviousPage as Page1;
        if (source != null)
        {
            string password = source.Password1;
            ...
        }
    }
