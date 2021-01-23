    protected void Page_Load(object sender, EventArgs e)
    {
            SqlConnection conn = new SqlConnection("Data Source = 'PAULO'; Initial Catalog=ShoppingCartDB;Integrated Security =True");
            SqlCommand cmd = new SqlCommand("select ID from CustomerDetails ", conn);
            SqlDataAdapter da = new SqlDataAdapter("", conn);
     DataTable dt = new DataTable();
    	da.fill(dt);
    int count=dt.Rows.Count;
    if (Count > 0)
    {
    for (int i = 0; i < Count; i++)
    {
    Label2.Text =dt1.Rows[i]["ID"].ToString();
    }
    }
    }
