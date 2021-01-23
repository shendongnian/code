    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
       {
            // Only perform this on the initial load
            LoadPrinterList();
       }
    }
