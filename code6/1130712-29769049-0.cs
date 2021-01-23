    protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.HasKeys() ||
                    !string.IsNullOrEmpty(Request.QueryString["m"]))
            {
                var m = Request.QueryString["m"];
    
                switch (m)
                {
                    case "InsertMethod":
                        InsertMethod("Name");
                        break;
                }
            }
        }
