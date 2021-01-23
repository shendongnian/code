    public static void Savedata()
    {
        if (HttpContext.Current != null)
        {
            Page page = (Page)HttpContext.Current.Handler;
            TextBox TextBox1 = (TextBox)page.FindControl("TextBox1");
     
            TextBox TextBox2 = (TextBox)page.FindControl("TextBox2");
        }
    }
