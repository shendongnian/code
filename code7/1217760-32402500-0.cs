    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("BRANCH", typeof(string));
                dt.Columns.Add("TYPE", typeof(string));
                dt.Columns.Add("ID", typeof(string));
                dt.Rows.Add(new object[] { "1V", "R", "ZZ"});
                dt.Rows.Add(new object[] { "1A", "R", "ZZ"});
                dt.Rows.Add(new object[] { "3", "W", "V"});
                dt.Rows.Add(new object[] { "2V", "R", "VW"});
                dt.Rows.Add(new object[] { "1", "R", "NI"});
                dt.Rows.Add(new object[] { "4", "I", "MA"});
                dt.Rows.Add(new object[] { "1B", "R", "SZ"});
                foreach (DataRow row in dt.AsEnumerable())
                {
                    row["BRANCH"] = Regex.Match(row["BRANCH"].ToString(), "\\d+").Value.ToString();
                }
     
            }
        }
    }
    ​
