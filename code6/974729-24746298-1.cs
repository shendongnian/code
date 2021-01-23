    public string FileLocation
    {   
       get
       {
          return "OpenFilePDF.ashx?fileVar=" + Session["fileName"];
       }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
    ...
    lnkViewProper.NavigateUrl = FileLocation;
    ...
    }
