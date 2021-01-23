    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication33
    {
        class Program
        {
            const stating FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                DataTable dtFile1 = new DataTable();
                StreamWriter writer = new StreamWriter(FILENAME);
                foreach (DataRow row in dtFile1.AsEnumerable())
                {
                    writer.WriteLine(string.Join("|", row.ItemArray.Select(x => x.ToString())) + "|");
                }
     
            }
        }
    }
