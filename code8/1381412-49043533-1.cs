    foreach (DataRow row in ds.Tables[0].Rows)
    {
        // Now here, you are iterating through a individual row.
        // ItemArray gives an index position of a cell within a row.
        
        m.Text = row.ItemArray[0].ToString();
        i.Text = row.ItemArray[1].ToString();
        d.Text = row.ItemArray[2].ToString();
        g.Text = row.ItemArray[3].ToString();
    
    }
