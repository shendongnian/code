    foreach(DataColumn dc in dt.Columns)
                {
                    colColl.Add(dc.Caption);
                }
                IList<Dictionary<string, string>> rowColl = new List<Dictionary<string, string>>();
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, string> row = new Dictionary<string, string>();
                    
                    foreach (DataColumn dc in dt.Columns)
                    {
                        row.Add(dc.ColumnName, dr[dc].ToString());
                    }
                    rowColl.Add(row);
                }
                SmartTable smartTable = new SmartTable
                {
                    ColumnCollection = colColl,
                    RowCollection = rowColl
                };
 
