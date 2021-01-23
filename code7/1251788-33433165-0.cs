     else if (e.CommandName == "Deleterow")
                {
                    GridViewRow gr = (GridViewRow)
    ((Button)e.CommandSource).NamingContainer;      
                    SqlCommand com = new SqlCommand("StoredProcedure4", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ID", gr.Cells[0].Text);
                    com.ExecuteNonQuery();
                    Remove this line//Response.Redirect("studententry.aspx");
                    Rebind grid here.
                }
