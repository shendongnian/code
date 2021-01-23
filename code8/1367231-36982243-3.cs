    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        var val1= row.Cells[4].Value + "";
                   
        var val2 = row.Cells[5].Value + "";
        
        DateTime dt1, dt2;//To store parsed values in dateTime variables
        
        // try to parse both values in columns
        if(DateTime.TryParse(val1, out dt1) &&
            DateTime.TryParse(val2, out dt2))
        {
            // both values are parsed successfully then assign    
            //computed result of two values in your MTTR column
                            
            row.Cells["MTTR"].Value = (dt1 - dt2) + "";
        }
    }
