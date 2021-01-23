    protected void Page_Load(object sender, EventArgs e)
    {
        Array data;
        if (IsPostback)
        {
            data = Session["data"] == null ? getDataFromWebserver() : Session["data"] // if session is null, go get data, otherwise use session variable.
        }
        else
        {
            // Go get you data, since it is a first load or a refresh
            // once you have data - put it in session
            Session["data"] =  getDataFromWebserver(); 
            data = Session["data"];
        } 
        MyGridViewExtension thisNewGridView=new MyGridViewExtension(data);
        thisNewGridView.DataBind();
        divName.Controls.Add(thisNewGridView); //add the gridview to a div on the page
        // No you can do whatever you need to do...
        // some code
    }
