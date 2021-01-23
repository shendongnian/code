               DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                ds.WriteXml("Filename", XmlWriteMode.WriteSchema);
                // read columns of datatable
                List<string> headers = new List<string>();
                foreach (DataColumn column in dt.Columns)
                {
                    headers.Add(column.ColumnName);
                    // type can be gotten from this
                    Type columnType = column.DataType;
                }​
