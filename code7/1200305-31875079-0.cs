    protected void Page_Load(object sender, EventArgs e)
        {
            str = Request.QueryString["Id"];
            ID = Convert.ToInt32(str);
            if (!IsPostBack)
                { 
            FirstArea2.Value = EditQuestion().name;
            editor.Value =System.Web.HttpUtility.HtmlDecode(EditQuestion().details.ToString());
                }
         }
