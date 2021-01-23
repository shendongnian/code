    protected void btnApprove_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                string status = GridView1.Rows[row.RowIndex].Cells[6].Text;
                if (status == "Received")
                {
                    error2.Visible = true;
                }
                else
                {
                    string ProductID = GridView1.Rows[row.RowIndex].Cells[1].Text;
                    int Quantity = int.Parse(GridView1.Rows[row.RowIndex].Cells[4].Text);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
    
                    cmd.CommandText = "INSERT INTO Receiving VALUES (@POID, @RequestedBy, " +
                        "@OrderBy, @PODate, @FinalDeliveryDate, @DateReceived, @ReceivedBy, @Status, @Remarks)";
                    cmd.Parameters.AddWithValue("@POID", Request.QueryString["ID"].ToString());
                    cmd.Parameters.AddWithValue("@RequestedBy", txtPRBy.Text);
                    cmd.Parameters.AddWithValue("@OrderBy", txtOrderBy.Text);
                    cmd.Parameters.AddWithValue("@PODate", txtPODate.Text);
                    cmd.Parameters.AddWithValue("@FinalDeliveryDate", txtFinalDelDate.Text);
                    cmd.Parameters.AddWithValue("@DateReceived", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ReceivedBy", txtLN.Text + txtFN.Text);
                    cmd.Parameters.AddWithValue("@Status", "Received");
                    cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                    cmd.ExecuteNonQuery();
    
                    cmd.CommandText = "UPDATE PO SET Status=@Status WHERE POID=@POID";
                    cmd.ExecuteNonQuery();
    
                    cmd.CommandText = "UPDATE Products SET Available+=@Quantity WHERE ProductID=@ProductID";
                    cmd.Parameters.Add("@ProductID", SqlDbType.VarChar).Value = ProductID.ToString();
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    cmd.ExecuteNonQuery();
    
                    GridView1.DataBind();
                    con.Close(); 
                }
            }
        }
    }
