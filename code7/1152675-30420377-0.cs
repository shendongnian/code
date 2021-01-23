    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("MenuLabel", typeof(string));
                dt.Columns.Add("ParentMenuId", typeof(int));
                dt.Rows.Add(new object[] {1, "Home",0});         // Main Menu
                dt.Rows.Add(new object[] {2, "MyAccounts",0});   // Main Menu
                dt.Rows.Add(new object[] {3, "MyProfile",2});    // Sub Menu, parent menu is MyAccounts
                dt.Rows.Add(new object[] {4, "Trade", 0});       // Main Menu
                dt.Rows.Add(new object[] {5, "Stock", 4});       // Sub Menu, parent menu is Trade
                dt.Rows.Add(new object[] {6, "Bonds", 4 });     // Sub Menu, parent menu is Trade
                Dictionary<int, List<DataRow>> parentDict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<int>("ParentMenuId"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                Dictionary<int, DataRow> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<int>("Id"), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                int menu = 3;
                List<DataRow> parents = new List<DataRow>();
                for (int row = menu; (int)dict[row]["ParentMenuId"] != 0; row = (int)dict[row]["ParentMenuId"])
                {
                    parents.Add(dict[(int)dict[row]["ParentMenuId"]]);
                }
            }
     
        }
     
    }
    ​
