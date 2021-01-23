    dataGridView4.DataSource = ds.Tables[0].AsEnumerable()
                                 .Select(row => new 
                                                {
                                                    Id = row.Field<int>("Id"),
                                                    Column2 = row.Field<string>("Column2"),
                                                    Col3 = ... // Put here the columns you want
                                                })
                                 .CopyToDataTable();
