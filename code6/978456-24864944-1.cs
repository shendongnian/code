         protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ( Request.Params["__EventTarget"] == null || !Request.Params["__EventTarget"].Contains("gridview1row"))
                {
                    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                    {
                        using (SqlCommand command =
                            new SqlCommand("SELECT TOP 100 * FROM dbo.TableName", connection))
                        {
                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = command;
                            da.Fill(ds);
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
