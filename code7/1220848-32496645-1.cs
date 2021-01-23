    private void Loadgrid()
            {
            
                var dt = new DataTable();
    
                using (var conn = new SqlConnection (ConfigurationManager.ConnectionStrings["ConnectionStringName"].ToString()))
                {
                    
                    var command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "SELECT * FROM [dbo].[T1]";
                    command.CommandType = CommandType.Text;
                    using (var adaptor = new SqlDataAdapter(command))
                    {
                        if (conn.State == ConnectionState.Closed) conn.Open();
                        adaptor.Fill(dt);
                        if (conn.State == ConnectionState.Open) conn.Close();
                    }
                    
                }
                    
                    Session["ss"] = dt;
                    grid2.DataSource = dt;
                    grid2.DataBind();
    
                }
    private void AddNewRowToGrid()
            {
                DataTable dt = (DataTable) Session["ss"];
                DataRow dr = null;
                DataRow newBlankRow1 = dt.NewRow();
                dt.Rows.Add(newBlankRow1);
                grid2.DataSource = dt;
                grid2.DataBind();
    
                Session["ss"] = dt;
            }
