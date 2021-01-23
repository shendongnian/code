    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                DataTable InventoryItem = new DataTable();
                InventoryItem.Columns.Add("Item", typeof(string));
                InventoryItem.Rows.Add(new object[] { "Shoes" });
                InventoryItem.Rows.Add(new object[] { "Ties" });
                InventoryItem.Rows.Add(new object[] { "Dresses" });
                DataTable InventoryItemLines = new DataTable();
                InventoryItemLines.Columns.Add("Item", typeof(string));
                InventoryItemLines.Columns.Add("Color", typeof(string));
                InventoryItemLines.Columns.Add("Active", typeof(Boolean));
                InventoryItemLines.Rows.Add(new object[] { "Shoes", "Red", true });
                InventoryItemLines.Rows.Add(new object[] { "Shoes", "Blue", true });
                InventoryItemLines.Rows.Add(new object[] { "Shoes", "Turquoise", false });
                InventoryItemLines.Rows.Add(new object[] { "Ties", "Red", true });
                InventoryItemLines.Rows.Add(new object[] { "Ties", "Stripped", true });
                InventoryItemLines.Rows.Add(new object[] { "Ties", "Pokerdot", false });
                InventoryItemLines.Rows.Add(new object[] { "Dresses", "Yellow", true });
                InventoryItemLines.Rows.Add(new object[] { "Dresses", "Blue", true });
                InventoryItemLines.Rows.Add(new object[] { "Dresses", "Violet", true });
                InventoryItemLines.Rows.Add(new object[] { "Tresses", "Stripped", false });
                var results = InventoryItem.AsEnumerable().Select(x => new
                {
                    item = x.Field<string>("Item"),
                    inactive = InventoryItemLines.AsEnumerable().Where(y => (y.Field<string>("Item") == x.Field<string>("Item")) && !y.Field<Boolean>("Active")).ToList()
                }).ToList();
            }
           
        }
    }
    ​
