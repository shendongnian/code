        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.Request.QueryString["hasProducts"].ToString() == "true")
                {
                    ArrayList al = Session["SelectedProducts"] as ArrayList;
                    if (al == null)
                        throw new ApplicationException("A product list is required.");
                    if (al.Count < 1)
                        throw new ArgumentException("No products selected");
                    string inStatement = string.Empty;
                    foreach (var item in al)
                    {
                        inStatement += al.ToString() + ", ";
                    }
                    inStatement = inStatement.Substring(0, inStatement.Length - 2);
                    //Product aProd = new Product();
                    SqlConnection con = new SqlConnection(strcon);
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE Product_ID in (" + inStatement + ")", con); 
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    con.Open();
                    adp.Fill(ds, "Products");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                }
