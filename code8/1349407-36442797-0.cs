    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostback)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["test"].ToString(); 
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("select location, id from events_det", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(com);
                        DataTable dt = new DataTable();
                        da.Fill(dt);  
                        DropDownList1.DataTextField = "location"; 
                        DropDownList1.DataValueField = "id";         
                        DropDownList1.DataSource = dt;   
                        DropDownList1.DataBind(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
