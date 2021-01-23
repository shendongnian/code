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
                dt.Columns.Add("A List Object", typeof(List<string>));
                List<string> names = null;
                names = new List<string>(new string[] {"John", "Mary"});
                dt.Rows.Add(names);
                names = new List<string>(new string[] { "Bob", "Carol", "Ted", "Alice" });
                dt.Rows.Add(names);
                names = new List<string>(new string[] { "Harry", "Sally"});
                dt.Rows.Add(names);
            }
        }
    }
    ​
