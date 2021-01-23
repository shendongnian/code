    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            var file = HttpContext.Current.Request.Files[0];
    
            RegisterAsyncTask(new PageAsyncTask(UploadToService(file, 
                hiddenAuthCode.Value, int.Parse(hiddenId.Value))));
        }
    }
