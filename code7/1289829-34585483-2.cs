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
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Selection", typeof(string));
                dt.Rows.Add(new object[] { "Color", "1,2,3" });
                dt.Rows.Add(new object[] { "Shape", "a,b" });
                dt.Rows.Add(new object[] { "Cut", "x" });
                dt.Rows.Add(new object[] { "Range", "y" });
                dt.Rows.Add(new object[] { "Purity", "8,9" });
                Recursion recursion = new Recursion(dt);
                List<string> results = recursion.GetData(0);
                string final = string.Join("|", results.ToArray());
            }
        }
        public class Recursion
        {
            public DataTable  data { get; set; }
            public Recursion(DataTable data)
            {
                this.data = data;
            }
            public List<string> GetData(int level)
            {
                if (level == data.Rows.Count - 1)
                {
                    return data.Rows[level].Field<string>("Selection").Split(new char[] {','}).Select(x => x.ToString()).ToList();
                }
                else
                {
                    List<string> children = GetData(level + 1);
                    List<string> results = data.Rows[level].Field<string>("Selection").Split(new char[] { ',' }).Select(x => children.Select(y => x + y)).SelectMany(z => z).ToList();
                    return results;
                }
            }
        }
    }
    ​
    ​
