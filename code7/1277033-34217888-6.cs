    var dictionary = new Dictionary<string, List<string>>();
    dictionary.Add("list1", list1);
    dictionary.Add("list2", list2);
    // And some othet lists ....
  
    int rowCount = dictionary.Cast<KeyValuePair<string, List<string>>>()
                             .Select(x=>x.Value.Count).Max();
            
    var dataTable = new DataTable();
    foreach (var key in dictionary.Keys)
    {
        dataTable.Columns.Add(key);
    }
    for (int i = 0; i < rowCount; i++)
    {
        var row = dataTable.Rows.Add();
        foreach (var key in dictionary.Keys)
        {
            try
            {
                row[key] = dictionary[key][i];
            }
            catch 
            {
                row[key] = null;
            }
        }
    }
    this.dataGridView1.AutoGenerateColumns = true;
    this.dataGridView1.DataSource = dataTable;
