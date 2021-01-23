    DataSet ds = new DataSet();
    connection.Open();
    adapter.Fill(ds);
    DataTable table = ds.Tables[0];
    
    foreach (DataRow row in dt.Rows)
    {
        for (int i = 0; i < row.ItemArray.Length; i++) 
        {
           string date = row.ItemArray[0].ToString();
           date = date.Remove(date.Length - 12);
           string val = row[i].ToString();
           row[i] = date;
           Debug.WriteLine("oldValue: {0}, newValue: {1}", val, row[i].ToString());
        }
    }
    invoicesDataGrid.AutoGenerateColumns = true;
    invoicesDataGrid.ItemsSource = table.DefaultView;
