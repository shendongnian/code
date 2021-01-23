     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
     {
	    bool status = false;
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                LinkButton link = ((LinkButton)GridView1.FindControl("btnApprove"));
		
                if (chkRow.Checked)
                {
			if(link.Text == "Approved")
			{
				status = true;	
			}
			else
			{
				status = false;
			}
                    using (SqlConnection scn = new SqlConnection("Data Source = 'PAULO'; Initial Catalog=ShoppingCartDB;Integrated Security =True"))
                    {
                        scn.Open();
                        SqlCommand cmd = new SqlCommand("update o set o.Updatedproduct = p.ProductQuantity - o.Totalproduct, o.ApproveStatus = @status from CustomerProducts o inner join Products p on o.ProductID = p.ProductID WHERE o.CustomerID=@CustomerID", scn);
                        cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.Int).Value = row.Cells[0].Text;
                        cmd.Parameters.AddWithValue("@status", status)
			            cmd.ExecuteNonQuery();
                        GridView1.DataBind();
                    }
                }
            }
        }
                  
