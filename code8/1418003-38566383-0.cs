    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("SlabFrom", typeof(int));
                dt.Columns.Add("SlabTo", typeof(int));
                dt.Columns["SlabTo"].AllowDBNull = true;
                dt.Columns.Add("Rate", typeof(double));
                dt.Rows.Add(new object[] {0,100,5.00});
                dt.Rows.Add(new object[] {100,500,10.00});
                dt.Rows.Add(new object[] {501,null,15.00});
                int usage = 1500;
                double cost = 0;
                foreach(DataRow row in dt.AsEnumerable())
                {
                    if(usage > 0)
                    {
                        if((row.Field<int?>("SlabTo") == null) || (usage < row.Field<int>("SlabTo")))
                        {
                            cost += usage * row.Field<double>("Rate");
                            usage = 0;
                        }
                        else
                        {
                             cost += (row.Field<int>("SlabTo") - row.Field<int>("SlabFrom")) * row.Field<double>("Rate");
                             usage -=  (row.Field<int>("SlabTo") - row.Field<int>("SlabFrom"));
                        }
                    }
                }
             }
        }
    }
