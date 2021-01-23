    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
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
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                States state = States.FIND_OUTPUT;
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
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
                                state = States.GET_DATA_TABLE;
                                break;
                            case States.GET_DATA_TABLE:
                                string[] dataArray = inputLine.Split(new char[] { '|' });
                                dt.Rows.Add(dataArray);
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
            }
        }
    }
    ​
