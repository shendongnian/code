    foreach (DataGridViewColumn c in GridView.Columns)
    {
        if( c.Name == "Something" )
        {
            //Skip this column
            continue;
        }
        //process these columns
        //..
    }
    for (int i = 0; i < GridView.Rows.Count - 1; i++)
    {
        for (int j = 0; j < GridView.Columns.Count - 1; j++)
        {
            if( GridView.Columns[j].Name == "Something" )
            {
                //Skip this column
                continue
            }
            //Process these columns
        }
    }
