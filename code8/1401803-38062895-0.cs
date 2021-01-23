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
                DataTable dt = new DataTable();
                dt.Columns.Add("Nationality", typeof(string));
                dt.Columns.Add("User Name", typeof(string));
                dt.Columns.Add("User Type", typeof(string));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("Total", typeof(decimal));
                dt.Columns.Add("City", typeof(string));
                dt.Columns.Add("Plan", typeof(string));
                dt.Rows.Add(new object[] { "BE", "Mike", "VIP", "A B", 2.000, "Brussels", "Monthly"});
                dt.Rows.Add(new object[] { "BE", "David", "VIP", "A B", 2.000, "Brussels", "Monthly" }); 
                dt.Rows.Add(new object[] { "BE", "Jill", "VIP", "A B C", 2.000, "Brussels", "Monthly" }); 
                dt.Rows.Add(new object[] { "BE", "Kim", "ST", "A B C", 2.000, "Antwerpen", "Monthly" });
                dt.Rows.Add(new object[] { "BE", "Sabrina", "ST", "A B C", 2.000, "Antwerpen", "Monthly" });
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Nationality", typeof(string));
                dt2.Columns.Add("UserCount", typeof(int));
                dt2.Columns.Add("TypeName", typeof(string));
                dt2.Columns.Add("Code", typeof(string));
                dt2.Columns.Add("GrandTotal", typeof(decimal));
                dt2.Columns.Add("City", typeof(string));
                dt2.Columns.Add("PaymentPlan", typeof(string));
      
                var groups = dt.AsEnumerable().GroupBy(x => new  {_type = x.Field<string>("User Type"), code = x.Field<string>("Code")});
                foreach (var group in groups)
                {
                    dt2.Rows.Add(new object[] {
                        group.FirstOrDefault().Field<string>("Nationality"),
                        group.Count(),
                        group.FirstOrDefault().Field<string>("User Type"),
                        group.FirstOrDefault().Field<string>("Code"),
                        group.Select(x => x.Field<decimal>("Total")).Sum(),
                        group.FirstOrDefault().Field<string>("City"),
                        group.FirstOrDefault().Field<string>("Plan")
                    });
                }
            }
        }
    }
