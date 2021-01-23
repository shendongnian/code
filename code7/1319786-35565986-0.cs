    var collection = new[] { "tbl1", "tbl2", "tbl3", "tbl4", "tbl5", "tbl6", "tbl7", "tbl8", "tbl9", "tbl10", "tbl11" };
                var dt = new DataTable();
                dt.Columns.Add("col1");
                dt.Columns.Add("col2");
                dt.Columns.Add("col3");
                dt.Columns.Add("col4");
    
                // Create the grid
                var countRows = Math.Ceiling((float)collection.Count() / dt.Columns.Count);
                for (var i = 0; i < countRows; i++)
                    dt.Rows.Add(dt.NewRow());
    
                // Fill the grid
                var countRow = 0;
                var countColumn = 0;
                foreach (var charachter in collection)
                {
                    dt.Rows[countRow][countColumn] = charachter;
                    countColumn++;
    
                    if (countColumn == 4)
                    {
                        countRow++;
                        countColumn = 0;
                    }
                }
    
                dataGridView1.DataSource = dt;
