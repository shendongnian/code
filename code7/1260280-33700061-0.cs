    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Demo1_CS
    {
        public class MonthDemo
        {
            /// <summary>
            /// Let's look at this as data coming back from a database table
            /// </summary>
            /// <returns></returns>
            public DataTable Table()
            {
                DataTable dt = new DataTable();
    
                dt.Columns.Add(new DataColumn()
                {
                    ColumnName = "ID",
                    DataType = typeof(int),
                    AutoIncrement = true
                });
                dt.Columns.Add(new DataColumn()
                {
                    ColumnName = "Month",
                    DataType = typeof(string)
                });
                dt.Columns.Add(new DataColumn()
                {
                    ColumnName = "Name",
                    DataType = typeof(string)
                });
    
                dt.Rows.Add(new object[] { null, "January", "Karen Payne" });
                dt.Rows.Add(new object[] { null, "January", "Bill Smith" });
                dt.Rows.Add(new object[] { null, "March", "George Jones" });
                dt.Rows.Add(new object[] { null, "April", "Frank White" });
    
                return dt;
    
            }
            /// <summary>
            /// Get a list of distinct month names
            /// </summary>
            /// <returns></returns>
            public List<string> MonthNames()
            {
                return Table()
                    .AsEnumerable()
                    .Select(row => row.Field<string>("Month"))
                    .Distinct()
                    .ToList();
            }
            public void Work()
            {
                // SQL responsible for creating sheets
                string createCommandText =
                            @"
                                CREATE TABLE {0}
                                (
                                    ID INT,
                                    Name CHAR(255)
                                )";
    
                // SQL responsible for inserting rows of data
                string insertCommandText = @"
                            INSERT INTO {0}
                            (
                                ID,
                                Name
                            )
                            VALUES
                            (
                                @ID,
                                @Name
                            )
                        ";
    
                // assumes this file exists
                string FileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DemoMonths.xlsx");
    
                List<DataRow> result;
    
                using (OleDbConnection cn = new OleDbConnection { ConnectionString = "TODO"})
                {
                    using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                    {
                        cmd.Parameters.Add(new OleDbParameter() { ParameterName = "@ID", DbType = DbType.Int32 });
                        cmd.Parameters.Add(new OleDbParameter() { ParameterName = "@MonthName", DbType = DbType.String });
                        cmd.Parameters.Add(new OleDbParameter() { ParameterName = "@Name", DbType = DbType.String });
    
                        // assume the file will open else use a try-catch
                        cn.Open();
    
                        // Iterate months, get rows and insert rows into proper sheet
                        foreach (string monthName in MonthNames())
                        {
                            result = Table().AsEnumerable().Where(row => row.Field<string>("Month") == monthName).ToList();
                            if (result.Count > 0)
                            {
                                foreach (DataRow row in result)
                                {
                                    // assumes sheet does not exists, create it
                                    cmd.CommandText = string.Format(createCommandText, monthName);
    
                                    try
                                    {
                                        // test if create sheet worked
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
    
                                            // load values into command object parameters
                                            cmd.CommandText = string.Format(insertCommandText, monthName);
                                            cmd.Parameters["@ID"].Value = row.Field<int>("ID");
                                            cmd.Parameters["@Name"].Value = row.Field<string>("Name");
    
                                            // insert row data
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // simply an example, best to say write to a log file
                                        Console.WriteLine("Failed to create or insert: {0}", ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
