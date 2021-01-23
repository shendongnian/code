    private void MyFirstMethod()
    {
        //Some Code
    }
    
    protected void Name_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "TextINeed")
        {
            MyFirstMethod();
        }
    }
    
    protected void btn_someButton(object sender, EventArgs e)
    {
        MyFirstMethod();
    }
