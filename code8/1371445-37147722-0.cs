            var data = new Dictionary<int, List<Tuple<string, object>>>();
            foreach (DataRow row in table1.Rows)
            {
                /* Pull data from "main" table */
                int id = Convert.ToInt32(row["MyId"]);
                var rowData = new List<Tuple<string, object>>();
                foreach (DataColumn column in table1.Columns)
                {
                    string columnName = column.ColumnName;
                    var columnData = new Tuple<string, object>(columnName, row[columnName]);
                    rowData.Add(columnData);
                }
                //Collect data from each related table
                foreach (DataRelation relation in set.Relations)
                {
                    foreach (DataRow relatedRow in row.GetChildRows(relation))
                    {
                        foreach (DataColumn column in relation.ChildTable.Columns)
                        {
                            if (relation.ChildColumns.Contains(column))
                            {
                                continue;
                            }
                            string columnName = column.ColumnName;
                            var columnData = new Tuple<string, object>(columnName, relatedRow[columnName]);
                            rowData.Add(columnData);
                        }
                    }
                }
                //Add to data dictionary
                data.Add(id, rowData);
            }
