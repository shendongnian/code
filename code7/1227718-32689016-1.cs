    protected void Button3_Click(object sender, EventArgs e)
            {
                Transaction tr = new Transaction();
                **GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;**
                HasinReservation.Entities.Db.Transaction dt = new Transaction();
                **int x = clickedRow.RowIndex;**
                SqlConnection connection = new SqlConnection(@"Data Source=192.168.10.4\Sql2008;Initial Catalog=GardeshgariKish;User ID=cms;Password=cms#123456;MultipleActiveResultSets=True;Application Name=EntityFramework");
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand("Update Transactions SET IsCancelled = 1 WHERE BarCodeNumber = @Value", connection);
               
                **string barcode = dgvData.Rows[x].Cells[12].Text;**
                sqlCmd.Parameters.AddWithValue("@Value", barcode);
                
                sqlCmd.ExecuteNonQuery();
                connection.Close();
                
            }
