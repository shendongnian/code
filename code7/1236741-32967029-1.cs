    public ActionResult Index(string TextBox1)
    {
        // You don't say how you're interacting with the database, 
        // but you need to check the `TextBox1` parameter for null, 
        // and use it in your query if it's not - simplified:
        if(TextBox1 != null)
        {
            // do qry with parameter
        }
        else
        {
           // do qry without parameter
        }
        ...
