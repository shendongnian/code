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
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("User", typeof(string));
                dt1.Columns.Add("Dept", typeof(string));
                dt1.Rows.Add(new object[] { "X","HR"});
                dt1.Rows.Add(new object[] { "Y","HR"});
                dt1.Rows.Add(new object[] { "Z","Admin"});
                dt1.Rows.Add(new object[] { "A","Corp"});
                dt1.Rows.Add(new object[] { "B","Admin"});
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("User", typeof(string));
                dt2.Columns.Add("Dept", typeof(string));
                dt2.Rows.Add(new object[] { "P","HR"});
                dt2.Rows.Add(new object[] { "Q","Corp"});
                dt2.Rows.Add(new object[] { "Z","Admin"});
                dt2.Rows.Add(new object[] { "A","Corp"});
                dt2.Rows.Add(new object[] { "B","Corp"});
                var groups = 
                    from emp2 in dt2.AsEnumerable()
                    join emp1 in dt1.AsEnumerable() on emp2.Field<string>("User") equals emp1.Field<string>("User") into ps 
                    from emp1 in ps.DefaultIfEmpty() 
                    select new { emp1 = emp1, emp2 = emp2};
                DataTable dt3 = new DataTable();
                dt3.Columns.Add("User", typeof(string));
                dt3.Columns.Add("Dept", typeof(string));
                foreach (var group in groups)
                {
                    if (group.emp1 == null)
                    {
                        dt3.Rows.Add(group.emp2.ItemArray);
                    }
                    else
                    {
                        if (group.emp2 != null)
                        {
                            if (group.emp1.Field<string>("Dept") != group.emp2.Field<string>("Dept"))
                            {
                                dt3.Rows.Add(group.emp2.ItemArray);
                            }
                        }
                    }
                }
            }
        }
    }
