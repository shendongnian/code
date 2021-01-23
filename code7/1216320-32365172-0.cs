    var dt = new DataTable();
    dt.Columns.Add("Enable", typeof(bool));
    var names = specList[0].Split(','); 
    for (int c = 0; c < names.Length; c++)
        dt.Columns.Add(names[c]);
    for (int i = 1; i < specList.Count; i++)
    {
        var dr = dt.Rows.Add();
        dr[0] = true;
        var values = specList[i].Split(',');
        for (int c = 0; c < values.Length; c++)
            dr[1 + c] = values[c];  
    }
    dataGridView2.DataSource = dt;
