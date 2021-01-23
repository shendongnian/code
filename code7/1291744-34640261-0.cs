    protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                  SqlConnection conn = new SqlConnection();
                  conn.ConnectionString = "Data Source=(local);Initial Catalog=MOE;Integrated Security=True";
                  conn.Open();
                  SqlCommand da = new SqlCommand("Select Itemid,ItemName from Item", conn);
                  DropDownList1.DataSource = da.ExecuteReader();
                  DropDownList1.DataTextField = "Itemname";
                  DropDownList1.DataValueField = "Itemid";
                  DropDownList1.DataBind();
                  conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
