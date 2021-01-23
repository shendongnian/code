                int i = Obj_Duration.Rows.IndexOf(row);
                if (AlternatingDataTableName.Rows.Count - 1 >= i)
                {
                    DataRow alternatingRow = AlternatingDataTableName.Rows[i];
                       //Start TR
                    foreach (DataColumn col in AlternatingDataTableName.Columns )
                    {
                        //Start TD
                         //alternatingRow[col.Ordinal].ToString()
                        //End TD
                    }
                    // end TR
                }
