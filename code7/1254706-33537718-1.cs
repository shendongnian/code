         else if (e.CommandName == "Deleterow")
                {     
                    SqlCommand com = new SqlCommand("StoredProcedure4", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ID", Convert.ToInt32(e.CommandArgument));
                    var id = Int32.Parse(e.CommandArgument.ToString());                
                    GridView1.Rows[id].Visible = false;
                    com.ExecuteNonQuery();
                    Response.Redirect("studententry.aspx");
    
                }
