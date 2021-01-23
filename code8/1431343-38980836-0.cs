    public void fillDataGridView()
    {
        using (SqlConnection connection = new SqlConnection(yourConnectionString))
            {
                using (SqlCommand scmd = new SqlCommand("[dbo].[GetIDbyID]", connection))
                {
                    connection.Open();
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@childname", comboBox.SelectedValue); //add as many parameters as you need
                    SqlDataAdapter sda = new SqlDataAdapter(scmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    connection.Close();
                    dataGridView.DataSource = dt;
                    dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); //this just autosizes the columns to their contents and is optional
                }
            }
    }
