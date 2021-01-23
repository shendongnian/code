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
                DataTable dt_vi = new DataTable();
                dt_vi.Columns.Add("wcID", typeof(int));
                dt_vi.Columns.Add("cID", typeof(int));
                dt_vi.Columns["cID"].AllowDBNull = true;
                dt_vi.Columns.Add("dftID", typeof(int));
                dt_vi.Columns["dftID"].AllowDBNull = true;
                dt_vi.Columns.Add("status", typeof(int));
                dt_vi.Columns["status"].AllowDBNull = true;
                DataTable dt_w = new DataTable();
                dt_w.Columns.Add("iD", typeof(int));
                dt_w.Columns.Add("name", typeof(string));
                DataTable dt_r = new DataTable();
                dt_r.Columns.Add("r_id", typeof(int));
                dt_r.Columns["r_id"].AllowDBNull = true;
                dt_r.Columns.Add("description", typeof(string));
                DataTable dt_d = new DataTable();
                dt_d.Columns.Add("dft_id", typeof(int));
                dt_d.Columns["dft_id"].AllowDBNull = true;
                dt_d.Columns.Add("dftAID", typeof(string));
                dt_d.Columns.Add("dftName", typeof(string));
                DataTable dt = new DataTable();
                dt.Columns.Add("qID", typeof(int));
                dt.Columns.Add("status", typeof(int));
                dt.Columns.Add("dfID", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("description", typeof(string));
                dt.Columns.Add("dftAID", typeof(string));
                dt.Columns.Add("dftName", typeof(string));
                
                dt_vi.Rows.Add(new object[] { 1, 1, 1, 1 });
                dt_vi.Rows.Add(new object[] { 2, 2, 2, 2 });
                dt_vi.Rows.Add(new object[] { 3, 3, 3, 3 });
                dt_vi.Rows.Add(new object[] { 4, 4, 4, 4 });
                dt_vi.Rows.Add(new object[] { 5, 5, 5, 5 });
                dt_w.Rows.Add(new object[] { 1, "a" });
                dt_w.Rows.Add(new object[] { 2, "b" });
                dt_w.Rows.Add(new object[] { 3, "c" });
                dt_w.Rows.Add(new object[] { 4, "d" });
                dt_w.Rows.Add(new object[] { 5, "e" });
                dt_r.Rows.Add(new object[] { 1, "f" });
                dt_r.Rows.Add(new object[] { 2, "g" });
                dt_r.Rows.Add(new object[] { 3, "h" });
                dt_r.Rows.Add(new object[] { 4, "i" });
                dt_r.Rows.Add(new object[] { 5, "j" });
                dt_d.Rows.Add(new object[] { 1, "k", "k" });
                dt_d.Rows.Add(new object[] { 2, "l", "l" });
                dt_d.Rows.Add(new object[] { 3, "m", "m" });
                dt_d.Rows.Add(new object[] { 4, "n", "n" });
                dt_d.Rows.Add(new object[] { 5, "o", "o" });
                var row = from r0w1 in dt_vi.AsEnumerable()
                          join r0w2 in dt_w.AsEnumerable()
                            on r0w1.Field<int>("wcID") equals r0w2.Field<int>("iD")
                          join r0w3 in dt_r.AsEnumerable()
                            on r0w1.Field<int?>("cID") equals r0w3.Field<int?>("r_id")
                          join r0w4 in dt_d.AsEnumerable()
                            on r0w1.Field<int?>("dftID") equals r0w4.Field<int?>("dft_id") into ps
                          from r0w4 in ps.DefaultIfEmpty()
                          select r0w1.ItemArray.Concat(r0w2.ItemArray.Concat(r0w3.ItemArray.Concat(r0w4 != null ? r0w4.ItemArray : new object[] { }))).ToArray();
                var rowAgain = from r0w1 in dt_vi.AsEnumerable()
                          join r0w2 in dt_w.AsEnumerable()
                            on r0w1.Field<int>("wcID") equals r0w2.Field<int>("iD")
                          join r0w3 in dt_r.AsEnumerable()
                            on r0w1.Field<int?>("cID") equals r0w3.Field<int?>("r_id")
                          join r0w4 in dt_d.AsEnumerable()
                            on r0w1.Field<int?>("dftID") equals r0w4.Field<int?>("dft_id") into ps
                          from r0w4 in ps.DefaultIfEmpty()
                          select new { 
                              cID = r0w1.Field<int?>("cID"),
                              status = r0w1.Field<int?>("status"),
                              defectID = r0w1.Field<int?>("dftID"),
                              name = r0w2.Field<string>("name"),
                              description = r0w3.Field<string>("description"),
                              dftAID = r0w4.Field<string>("dftAID"),
                              dftName = r0w4.Field<string>("dftName")
                          };
                foreach(var q in rowAgain.AsEnumerable())
                {
                    dt.Rows.Add(q.cID, q.status, q.defectID, q.name, q.description, q.dftAID, q.dftName);
                }
            }
        }
    }
    ​
