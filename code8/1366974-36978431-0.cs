            if (!this.IsPostBack)
            {
                DropDownList DropDownList1;
                for (int i = 0; i < 5; i++)
                {
                    DropDownList1 = (DropDownList)FindControl("dropdownlist" + i);
                    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT ID, Name FROM RejectedProduct"))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            DropDownList1.DataSource = cmd.ExecuteReader();
                            DropDownList1.DataTextField = "Name";
                            DropDownList1.DataValueField = "ID";
                            DropDownList1.DataBind();
                            con.Close();
                        }
                    }
                    DropDownList1.Items.Insert(0, new ListItem("Select Item for adding", "0"));
                }
            }
