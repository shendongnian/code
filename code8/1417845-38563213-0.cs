    for (int i = 0; i < gridView1.VisibleRowCount; i++)
    {
        var row = gridView1.GetDataRow(i);
        var genre = row["ColumnName"].ToString(); //ColumnName is your genre Column name
        
        if(genre.StartsWith(textBox6.text)){
           //here you can set row sellected
        }
    }
