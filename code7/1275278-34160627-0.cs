    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        
            using (Con = new MySqlConnection(ConnStr))
            {
                Con.Open();
                using (Cmd = new MySqlCommand("SELECT * FROM truckinfo", Con))
                {
        
                    using (Rdr = Cmd.ExecuteReader())
                    {
                        if (Rdr.HasRows)
                        {
                            DropDownList1.DataSource = Rdr;
                            DropDownList1.DataValueField = "truckplateno";
                            DropDownList1.DataTextField =  "truckplateno";
                            DropDownList1.DataBind();
                        }
                    }
                }
            }
        }
    }
