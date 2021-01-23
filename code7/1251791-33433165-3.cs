                else if (e.CommandName == "Deleterow")
                {
                    GridViewRow gr = (GridViewRow)
                    ((Button)e.CommandSource).NamingContainer;      
                    SqlCommand com = new SqlCommand("StoredProcedure4", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ID", gr.Cells[0].Text);
                    com.ExecuteNonQuery();
                    //Response.Redirect("studententry.aspx"); Remove this line
                    //call method here you have used to populate the gridview at page load.  
                }
