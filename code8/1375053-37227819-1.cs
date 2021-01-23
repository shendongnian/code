    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
		{
			Label3.Text = Request.QueryString["name"];//show welcome text
			String cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			using (SqlConnection sc = new SqlConnection(cs))
			{
				SqlCommand sqlcom = new SqlCommand("Select id, productname, price from productdata", sc);
				sc.Open();
				DropDownList1.DataTextField = "productname";//show in the dropdown list
				DropDownList1.DataValueField = "price"; //show in the label
				DropDownList1.DataSource = sqlcom.ExecuteReader();
				DropDownList1.DataBind();
			}
		}
    }
    protected void GetPrice(object sender, EventArgs e)
    {
        Label1.Text = DropDownList1.SelectedValue;
    }
