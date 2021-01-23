    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication45
    {
        class Program
        {
            static void Main(string[] args)
            {
               List<Sales> sales = new List<Sales>() {
                   new Sales() {
                       year = 2015, item = "Banana", sales = new Dictionary<string,double>() {
                         {"Week1", 2}, {"Week2", 24},{"Week3", 69}
                       }
                   },
                                  new Sales() {
                       year = 2015, item = "Apple", sales = new Dictionary<string,double>() {
                         {"Week1", 3}, {"Week2", 4},{"Week3", 8}
                       }
                   }
               };
               DataTable dt = new DataTable();
                dt.Columns.Add("Year", typeof(int));
                dt.Columns.Add("Category", typeof(string));
                dt.Columns.Add("Week1", typeof(int));
                dt.Columns.Add("Week2", typeof(int));
                dt.Columns.Add("Week3", typeof(int));
                foreach(Sales sale in sales)
                {
                    dt.Rows.Add(new object[] {
                        sale.year,
                        sale.item,
                        sale.sales["Week1"],
                        sale.sales["Week2"],
                        sale.sales["Week3"]
                    });
                 }
            }
        }
        public class Sales
        {
            public int year { get; set; }
            public string item { get; set; }
            public Dictionary<string, double> sales { get; set; }
        } 
    }
