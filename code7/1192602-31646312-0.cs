    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                int prodid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["ProductID"].ToString());
                SqlConnection conn = new SqlConnection("Data Source = 'PAULO'; Initial Catalog=Authorship;Integrated Security =True");
                SqlDataAdapter da = new SqlDataAdapter("", conn);
                conn.Open();
                da.DeleteCommand = new SqlCommand("delete from Products where ProductID=" + prodid, conn);
                da.DeleteCommand.ExecuteNonQuery();
                conn.Close();
                //GridView1.DataBind();
               gvbind();
            }
