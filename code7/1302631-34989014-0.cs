    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.Common;
    using System.Data;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable table = DbProviderFactories.GetFactoryClasses();
    
                // Display each row and column value.
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine("{0}:{1}",column.ColumnName,  row[column]);
                    }
                    Console.WriteLine("----------------------------");
                }
               
            }
        }
    }
