    da = new SqlDataAdapter("select * from Log where Username= '" + TextBox3.Text + "' and Password= '" + TextBox5.Text + "'", cn);
                
                ds = new DataSet();
                da.Fill(ds, "Log");
               
                if (ds.Tables[0].Rows.Count != 0)
                {
                    
                    Response.Redirect("Aspxpage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('INVALID ADMIN');</script>");
                }
