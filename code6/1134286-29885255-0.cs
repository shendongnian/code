    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Data.SqlClient;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            enum States
            {
                FIND_OUTPUT,
                GET_SEPERATOR,
                GET_TABLE_HEADER,
                GET_DATA_TABLE,
                END
            }
            static void Main(string[] args)
            {
     
                States state = States.FIND_OUTPUT;
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                string connStr = "Enter your connection string here";
                SqlConnection conn = new SqlConnection(connStr);
                string[] headers = null;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        switch (state)
                        {
                            case States.FIND_OUTPUT:
                                if (inputLine.StartsWith("OUTPUT (SQL Server Table)"))
                                    state = States.GET_SEPERATOR;
                                break;
                            case States.GET_SEPERATOR:
                                state = States.GET_TABLE_HEADER;
                                break;
                            case States.GET_TABLE_HEADER:
                                headers = inputLine.Split(new char[] { '|'}, StringSplitOptions.RemoveEmptyEntries);
                                headers = headers.Select(x => x.Trim()).ToArray();
                                state = States.GET_DATA_TABLE;
                                break;
                            case States.GET_DATA_TABLE:
                                string[] dataArray = inputLine.Split(new char[] { '|'}, StringSplitOptions.RemoveEmptyEntries);
                                dataArray = dataArray.Select(x => x.Trim()).ToArray();
                                string commandText = string.Format("Insert into table1 ({0}) values ({1})", string.Join(",", headers), "'" + string.Join("','", dataArray) + "'");
                                SqlCommand cmd = new SqlCommand(commandText, conn);
                                cmd.ExecuteNonQuery();
                                break;
                        }
                    }
                    else
                    {
                        if (state == States.GET_DATA_TABLE)
                            break; //exit while loop if blank row at end of data table
                    }
                }
                reader.Close();
                conn.Close();
            }
        }
    }
    ​
