    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication34
    {
        class Program
        {
            const string FILENAME = @"C:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("PlayerId", typeof(int));
                dt.Columns.Add("PlayerName", typeof(string));
                dt.Columns.Add("Team", typeof(string));
                dt.Columns.Add("Postition", typeof(string));
                dt.Rows.Add(new object[] {1,"Nobody", "Team A", "Striker"});
                dt.Rows.Add(new object[] {1,"Nobody", "Team B", "Center Midfield"});
                dt.Rows.Add(new object[] {1,"Nobody", "Team C", "Substitute"});
                dt.Rows.Add(new object[] {2,"Chuck Norris", "Team A", "ALL"});
                dt.Rows.Add(new object[] {2,"Chuck Norris", "Team B", "Substitute"});
                DataTable results = dt.AsEnumerable()
                    .Where(x => x.Field<int>("PlayerId") == 1).ToList().CopyToDataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(results);
                ds.WriteXml(FILENAME, XmlWriteMode.WriteSchema);
            }
            
        }
    }
