        protected void btnresult_Click(Object sender, EventArgs e)
                {
                        Button btn = (Button)(sender);
                       //Get the row that contains this Button
                       GridViewRow gvr = btn.NamingContainer as GridViewRow;
                       SqlCommand com = new SqlCommand("sp_studentresultentry", con);
                       com.CommandType = CommandType.StoredProcedure;
                       com.Parameters.AddWithValue("@id_student", textstudentid.Text.Trim()); // Pass your required Parameters
                       com.Parameters.AddWithValue("@id",btn.CommandArgument);                
                       SqlDataAdapter adp = new SqlDataAdapter(com);
                       DataSet ds = new DataSet();
                       adp.Fill(ds); 
                       if(ds.Tables[0].Rows.Count >0)
                       {              
                        Response.Write("<script>");
                        Response.Write("window.open('studentresult.aspx?id=" + btn.CommandArgument + "','_blank')");
                        Response.Write("</script>");
                       }
                       else
                       {
                         Label LabelID = gvr.Cells[columnNo].FindControl("lblId") as Label;
                         LabelID.Text = "Marks didn't updated";
                       }
                    }
         
