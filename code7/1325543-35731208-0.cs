       protected void Page_Load(object sender, EventArgs e)
       {
            if (!Page.IsPostBack)
            {
                var firstDate = Request.QueryString["firstDate"] ?? DateTime.Now;
                var secondDate = Request.QueryString["secondDate"] ?? DateTime.Now.AddDays(1);
                BindDataGrid1(firstDate, secondDate);
            }
        }
