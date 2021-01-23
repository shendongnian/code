    //Add your lists to the dictionary
    var dictionary = new Dictionary<string, List<string>>();
    dictionary.Add("list1", list1);
    dictionary.Add("list2", list2);
    // And some othet lists ....
  
    //Calculate the count of rows.
    int rowCount = dictionary.Cast<KeyValuePair<string, List<string>>>()
                             .Select(x=>x.Value.Count).Max();
            
    //Create the data table and for each table, add a column
    var dataTable = new DataTable();
    foreach (var key in dictionary.Keys)
    {
        dataTable.Columns.Add(key);
    }
    //Add items of each list to the columns of rows of table
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
    //Show data in grid
    this.dataGridView1.AutoGenerateColumns = true;
    this.dataGridView1.DataSource = dataTable;
