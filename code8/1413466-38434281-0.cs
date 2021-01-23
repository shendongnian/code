    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl myDiv = new HtmlGenericControl("div");
        myDiv.ID = "myDiv";
        myDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Blue");
        this.Controls.Add(myDiv);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Application["MyData"] = "Supposed to be printed inside myDiv.";
    }
