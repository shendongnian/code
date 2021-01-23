    string[,] column0Array = new string[dataGridView1.Rows.Count,3];
                int i = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    column0Array[i,1] = row.Cells[4].Value + "";
                    i++;
                    column0Array[i,2] = row.Cells[5].Value + "";
    
                    DateTime dt1, dt2;//To store parsed values in dateTime variables
    
                    // try to parse both values in columns
                    if(DateTime.TryParse(column0Array[i,1], out dt1) &&
                    DateTime.TryParse(column0Array[i,2], out dt2))
                    {
                        // both values are parsed successfully then assign    
                       //computed result of two values in your column0Array[i,0]
                        
                       column0Array[i,0] = (dt1 - dt2) + "";
                    }
                    i++;
                }
