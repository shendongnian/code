     string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("RETRIEVE_RECIPE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
    
                    SqlParameter paramId = new SqlParameter()
                    {
                        ParameterName = "@RecipeId",
                        Value = o //Object from the datatable
    
                };
                    cmd.Parameters.Add(paramId);
                    con.Open();
                    byte[] bytes = (byte[])cmd.ExecuteScalar();
    
                    if (bytes != null)
                    {
                        string strBase64 = Convert.ToBase64String(bytes);
                        Image1.ImageUrl = "data:Image/png;base64," + strBase64;
                    }
                    else
                    {
                        Image1.ImageUrl = "~/images/NoImageAvail.jpg";
                    }
                }
