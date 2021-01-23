        try
            {
             using (SqlConnection con = new SqlConnection(sqlconn))
             {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = con;
                   con.Open();
                   for (int i = 1; i < dataGridView.Rows.Count; i++)
                   {         
                    string sql = @"INSERT INTO ERSBusinessLogic VALUES ("
                                 +dataGridView.Rows[i].Cells["ERSBusinessLogic_ID"].Value + ", "
                                    + dataGridView.Rows[i].Cells["ERSBusinessLogic_Formula"].Value + ", "
                                    + dataGridView.Rows[i].Cells["ERSBusinessLogic_InputsCount"].Value + ", "
                                    + dataGridView.Rows[i].Cells["ERSBusinessLogic_Inputs"].Value + ");";
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                  }
             }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            con.Close();
        }
