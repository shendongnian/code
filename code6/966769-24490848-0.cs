    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostback)
            {
             Array data=getDataFromWebserver(); //works
             MyGridViewExtension thisNewGridView=new MyGridViewExtension(data);
             thisNewGridView.DataBind();
             divName.Controls.Add(thisNewGridView); //add the gridview to a div on the page
            }
    }
