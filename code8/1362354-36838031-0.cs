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
                dt.Columns.Add("cid", typeof(string));
                dt.Columns.Add("usrnme", typeof(string));
                dt.Columns.Add("pname", typeof(string));
                dt.Columns.Add("prate", typeof(int));
                dt.Columns.Add("cabin", typeof(string));
                dt.Rows.Add(new object[] { "c11", "demo1@gmail.com", "sample1", 2000, "B2" });
                dt.Rows.Add(new object[] { "c14", "demo2@live.com", "sample2", 5000, "B3" });
                dt.Rows.Add(new object[] { "c15", "demo3@yahoo.com", "sample3", 8000, "B2" });
                dt.Rows.Add(new object[] { "c11", "demo1@gmail.com", "sample1", 2000, "B2" });
                dt.Rows.Add(new object[] { "c18", "demo4@gmail.com", "sample4", 3000, "L1" });
                dt.Rows.Add(new object[] { "c11", "demo5@gmail.com", "sample5", 7400, "B4" });
                dt = dt.AsEnumerable().Select(x => new UniqueColumns(x)).Distinct().Select(y => y.row).CopyToDataTable();
            }
        }
        public class UniqueColumns : EqualityComparer<UniqueColumns>
        {
            public DataRow row { get; set; }
            public UniqueColumns(DataRow row)
            {
                this.row = row;
            }
            public override int GetHashCode(UniqueColumns _this)
            {
                int hash = 0;
                foreach(var x in _this.row.ItemArray){hash ^= x.GetHashCode();} ;
                return hash;
            }
            public override int GetHashCode()
            {
                return this.GetHashCode(this);
            }
            public override Boolean Equals(UniqueColumns _this, UniqueColumns other)
            {
                Boolean results = _this.row.ItemArray.Select((x,i) => x.Equals(other.row.ItemArray[i])).All(y => y);
                return results;
            }
            public override bool Equals(object other)
            {
                return this.Equals(this, (UniqueColumns)other);
            }
        }
    }
