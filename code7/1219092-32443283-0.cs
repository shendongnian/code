    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static List<DataRow> menu = new List<DataRow>();
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MENUID", typeof(int));
                dt.Columns.Add("MENUNAME", typeof(string));
                dt.Columns.Add("ACTIVE", typeof(string));
                dt.Columns.Add("PARENTID", typeof(int));
                dt.Columns.Add("ORDERNO", typeof(int));
                dt.Columns.Add("URL", typeof(string));
                dt.Columns.Add("APPLICATION_ID", typeof(string));
                dt.Columns.Add("ROLER_ID", typeof(int));
                dt.Rows.Add(new object[] { 0, "Main Menu", "Y", -1, 0, "", "Main", 1 });
                dt.Rows.Add(new object[] { 11, "Feedback on System", "Y", 2, 2, "~ASPX/UserFeedBack.aspx", "Tester", 1 });
                dt.Rows.Add(new object[] {3,   "Reference Data",  "Y",   0,   3, "Tester",  1});
                dt.Rows.Add(new object[] {26,  "TAC", "Y",   3,   3, "Tester",  1});
                dt.Rows.Add(new object[] {27,  "LAC", "Y",   3,   3, "Tester",  1});
                DataRow main = dt.AsEnumerable().Where(x => x.Field<int>("MENUID") == 0).FirstOrDefault();
                menu.Add(main);
                
                GetChildren(dt, main);
            }
            static void GetChildren(DataTable dt, DataRow row)
            {
                int id = row.Field<int>("MENUID");
                List<DataRow> children = dt.AsEnumerable().Where(x => x.Field<int>("PARENTID") == id).ToList();
                foreach (DataRow child in children)
                {
                    Program.menu.Add(child);
                    GetChildren(dt, child);
                }
            }
        }
        
    }
    ​
