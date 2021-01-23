      using System;
      using System.Collections.Generic;
      using System.Data;
      using System.Data.Common;
      using System.Data.SqlClient;
      using System.Linq;
      using System.Reflection;
      namespace DatabaseUtilities
      {
          public static class RapidDataTools
          {
              const int SCHEMA_SCHEMA_NAME = 1;
              const int SCHEMA_TABLE_NAME = 2;
              const int BATCH_SIZE = 1000;
              /// <summary>
              /// Imports an array of data into a specified table. It does so by mapping object properties
              /// to table columns. Only properties with the same name as the column name will be copied;
              /// other columns will be left null. Non-nullable columns with no corresponding property will
              /// throw an error.
              /// </summary>
              /// <param name="connectionString"></param>
              /// <param name="destTableName">Qualified table name (e.g. Admin.Table)</param>
              /// <param name="sourceData"></param>
              /// <returns></returns>
              public static string Import<T>(string connectionString, string destTableName, T[] sourceData)
              {
                  //get destination table qualified name
                  string[] tableParts = destTableName.Split('.');
                  if (tableParts.Count() != 2) return $"Invalid or unqualified destination table name: {destTableName}.";
                  string destSchema = tableParts[0];
                  string destTable = tableParts[1];
                  //create the database connection
                  SqlConnection conn = GetConnection(connectionString);
                  if (conn == null) return "Invalid connection string.";
                  //establish connection
                  try { conn.Open(); }
                  catch { return "Could not connect to database using provided connection string."; }
                  //make sure the requested table exists
                  string foundTableName = string.Empty;
                  foreach (DataRow row in conn.GetSchema("Tables").Rows)
                      if (row[SCHEMA_SCHEMA_NAME].ToString().Equals(destSchema, StringComparison.CurrentCultureIgnoreCase) &&
                          row[SCHEMA_TABLE_NAME].ToString().Equals(destTable, StringComparison.CurrentCultureIgnoreCase))
                      {
                          foundTableName = $"{row[SCHEMA_SCHEMA_NAME]}.{row[SCHEMA_TABLE_NAME]}";
                          break;
                      }
                  if (foundTableName == string.Empty) return $"Specified table '{destTableName}' could not be found in table.";
                  //get all the column names for the table to build mapping object
                  SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM {foundTableName}", conn);
                  SqlDataReader reader = command.ExecuteReader();
                  //build mapping object by iterating through rows and verifying that there is a match in the table
                  var mapper = new List<Tuple<string, Func<object, string, object>>>();
                  foreach (DataRow col in reader.GetSchemaTable().Rows)
                  {
                      //get column information
                      string columnName = col.Field<string>("ColumnName");
                      PropertyInfo property = typeof(T).GetProperty(columnName);
                      Func<object, string, object> map;
                      if (property == null)
                      {
                          //check if it's nullable and exit if not
                          bool nullable = col.Field<bool>("Is_Nullable");
                          if (!nullable)
                              return $"No corresponding property found for Non-nullable field '{columnName}'.";
                          //if it's nullable, create mapping function
                          map = new Func<object, string, object>((a, b) => null);
                      }
                      else
                          map = new Func<object, string, object>((src, fld) => typeof(T).GetProperty(fld).GetValue(src));
                      //add mapping object
                      mapper.Add(new Tuple<string, Func<object, string, object>>(columnName, map));
                  }
                  //get all the data
                  int dataCount = sourceData.Count();
                  var rows = new DataRow[dataCount];
                  DataTable destTableDT = new DataTable();
                  destTableDT.Load(reader);
                  for (int x = 0; x < dataCount; x++)
                  {
                      var dataRow = destTableDT.NewRow();
                      dataRow.ItemArray = mapper.Select(m => m.Item2.Invoke(sourceData[x], m.Item1)).ToArray();
                      rows[x] = dataRow;
                  }
                  //close the old connection
                  conn.Close();
                  //set up the bulk copy connection
                  SqlBulkCopy sbc = new SqlBulkCopy(conn, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.UseInternalTransaction, null);
                  sbc.DestinationTableName = foundTableName;
                  sbc.BatchSize = BATCH_SIZE;
                  //establish connection
                  try { conn.Open(); }
                  catch { return "Failed to re-established connection to the database after reading data."; }
                  //write data
                  try { sbc.WriteToServer(rows); }
                  catch (Exception ex) { return $"Batch write failed. Details: {ex.Message} - {ex.StackTrace}"; }
                  //if we got here, everything worked!
                  return string.Empty;
              }
              private static SqlConnection GetConnection(string connectionString)
              {
                  DbConnectionStringBuilder csb = new DbConnectionStringBuilder();
                  try { csb.ConnectionString = connectionString; }
                  catch { return null; }
                  return new SqlConnection(csb.ConnectionString);
              }
          }
      }
