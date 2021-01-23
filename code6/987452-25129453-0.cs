    private void updateStock()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string constring = @"Data Source=|DataDirectory|\LWADataBase.sdf";
                string Query = "UPDATE stockTBL SET Quantity = Quantity - @quantity where [Item Name] = @name";
                using (SqlCeConnection conDataBase = new SqlCeConnection(constring))
                using (SqlCeCommand cmd = new SqlCeCommand(Query, conDataBase))
                {
                    try
                    {
                        conDataBase.Open();
                        cmd.Parameters.Add(new SqlCeParameter("@name", Convert.ToString(dataGridView1.Rows[i].Cells[0].Value)));
                        cmd.Parameters.Add(new SqlCeParameter("@quantity", Convert.ToString(dataGridView1.Rows[i].Cells[4].Value)));
                        int rowsUpdated = cmd.ExecuteNonQuery();
                        conDataBase.Close();
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message);
                     }
                  }
              }
          }
