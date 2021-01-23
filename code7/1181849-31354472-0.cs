    public void LoadDatabase()
    {
        _connection.Open();
        _dataAdapter.Fill(_dataTable);
        Program.AnimalInfo.Info_ID_ListBox.Items.Clear();
        try
        {
            foreach (DataRow row in _dataTable.Rows)
            {
                Program.AnimalInfo.Info_ID_ListBox.Items.Add(row["Animal_ID"].ToString());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to LoadDatabase()" + ex.Message);
        }
        _connection.Close();     
    }
