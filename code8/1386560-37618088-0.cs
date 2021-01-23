                    dtCloned = dataExcelInputTable.Clone();
                    dtCloned.Columns[1].DataType = typeof(System.String); // clone the datatble and make a column datatype to string
                    foreach (DataRow row in dataExcelInputTable.Rows)
                    {
                        dtCloned.ImportRow(row);
                    }
    
                    foreach (System.Data.DataRow row in dtCloned.Rows)
                    {
                        row["CODE"] = row["CODE"].ToString().PadLeft(8, '0');
                        Response.Write("<br/>" + row["CODE"]);
                    }
                    dtCloned.AcceptChanges();
