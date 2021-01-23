    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME1 = @"C:\temp\test.xml";
     
            static void Main(string[] args)
            {
                DataSet ds = new DataSet();
                DataTable callsDT = new DataTable();
                ds.Tables.Add(callsDT);
                callsDT.Columns.Add("id", typeof(Int32));
                callsDT.Columns.Add("origination", typeof(String));
                callsDT.Columns.Add("start_time", typeof(DateTime));
                callsDT.Columns.Add("from", typeof(String));
                callsDT.Columns.Add("from_name", typeof(String));
                callsDT.Columns.Add("from_number", typeof(long));
                List<List<object>> input = new List<List<object>>(){
                   new List<object>() {55555, "incoming", DateTime.Parse("2001-01-01 00:00:00"), "John",  "Doe", 5555555555},
                   new List<object>() {55556, "incoming", DateTime.Parse("2001-01-02 00:00:00"), "Mary",  "Smith", 5555555556},
                   new List<object>() {55557, "incoming", DateTime.Parse("2001-01-03 00:00:00"), "Rob",  "Robon", 55555555557},
                   new List<object>() {55558, "incoming", DateTime.Parse("2001-01-04 00:00:00"), "Sally",  "Rode", 5555555558}
                };
                foreach(List<object> newRow in input)
                {
                    callsDT.Rows.Add(newRow.ToArray());
                }
                ds.WriteXml(FILENAME1, XmlWriteMode.WriteSchema);
                ds = null;
                ds = new DataSet();
                ds.ReadXml(FILENAME1, XmlReadMode.ReadSchema);
                
            }
        }
    }
    ​
