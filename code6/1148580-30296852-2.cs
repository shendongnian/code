    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        //whatever you want to pass , write it in yourfnname as a parameter
        btnreset.Attributes.Add("onclick", "return YorFnName('test')");
    }
