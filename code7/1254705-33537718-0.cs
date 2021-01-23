           else if (e.CommandName == "Deleterow")
                {
                    GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;      
                    SqlCommand com = new SqlCommand("StoredProcedure4", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ID", gr.Cells[0].Text);
                    var id = Int32.Parse(e.CommandArgument.ToString());                
                    GridView1.Rows[id].Visible = false;
                    com.ExecuteNonQuery();
                    Response.Redirect("studententry.aspx");
    
                }
