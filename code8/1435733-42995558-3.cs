        public List<object[]> RunSql(string sqlString, bool includeColumnNamesAsFirstRow)
        {
            var lstRes = new List<object[]>();
            SQLitePCL.sqlite3_stmt stQuery = null;
            try
            {
                stQuery = SQLite3.Prepare2(fieldStrikeDatabase.Connection.Handle, sqlString);
                var colLenght = SQLite3.ColumnCount(stQuery);
                if (includeColumnNamesAsFirstRow)
                {
                    var obj = new object[colLenght];
                    lstRes.Add(obj);
                    for (int i = 0; i < colLenght; i++)
                    {
                        obj[i] = SQLite3.ColumnName(stQuery, i);
                    }
                }
                while (SQLite3.Step(stQuery) == SQLite3.Result.Row)
                {
                    var obj = new object[colLenght];
                    lstRes.Add(obj);
                    for (int i = 0; i < colLenght; i++)
                    {
                         var columnType = SQLitePCL.raw.sqlite3_column_decltype(stQuery, i);
                         switch (columnType)
                         {
                             case "text":
                                  obj[i] = SQLite3.ColumnString(stQuery, i);
                                  break;
                             case "int":
                                   obj[i] = SQLite3.ColumnInt(stQuery, i);
                                   break;
                             case "real":
                                   obj[i] = SQLite3.ColumnDouble(stQuery, i);
                                   break;
                             case "blob":
                                   obj[i] = SQLite3.ColumnBlob(stQuery, i);
                                   break;
                             case "null":
                                   obj[i - startColumnIndex] = null;
                                   break;
                          }
                    }
                }
                return lstRes;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (stQuery != null)
                {
                    SQLite3.Finalize(stQuery); 
                }
            }
        }
