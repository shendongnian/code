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
                DataColumn col = null;
                DataTable original = new DataTable();
                col = original.Columns.Add("ean", typeof(int));
                col.AllowDBNull = true;
                col = original.Columns.Add("skunum", typeof(int));
                col.AllowDBNull = true;
                col = original.Columns.Add("prodname", typeof(string));
                col.AllowDBNull = true;
                
                original.Rows.Add(new object[] {111, null, "bread"});
                original.Rows.Add(new object[] {222, null, "cheese"});
                DataTable enhancement = new DataTable();
                col = enhancement.Columns.Add("ean", typeof(int));
                col.AllowDBNull = true;
                col = enhancement.Columns.Add("skunum", typeof(int));
                col.AllowDBNull = true;
                col = enhancement.Columns.Add("prodname", typeof(string));
                col.AllowDBNull = true;
                
                enhancement.Rows.Add(new object[] {111, 555, "foo"});
                enhancement.Rows.Add(new object[] {333, 444, "foo"});
                var joinedObject = (from o in original.AsEnumerable()
                                    join e in enhancement.AsEnumerable() on o.Field<int>("ean") equals e.Field<int>("ean")
                                    select new { original = o, enhancement = e }).ToList();
                foreach (var row in joinedObject)
                {
                    row.original["skunum"] = row.enhancement["skunum"];
                    row.original["prodname"] = row.enhancement["prodname"];
                }
            }
        }
    }
    ​
