    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PackageID", typeof(int));
            dt.Columns.Add("Amount", typeof(int));
            dt.Columns.Add("Auto_sync", typeof(bool));
            dt.Columns.Add("Color", typeof(string));
            dt.Rows.Add(new object[] { 226, 15000, true, "BLUE" });
            dt.Rows.Add(new object[] { 500, 15000, true, "PEACH" });
            Foo foo = new Foo
            {
                BrokerID = "998",
                AccountID = "1313",
                Packages = dt
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new CustomDataTableConverter());
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(foo, settings);
            Console.WriteLine(json);
            Console.WriteLine();
            Foo foo2 = JsonConvert.DeserializeObject<Foo>(json, settings);
            Console.WriteLine("BrokerID: " + foo2.BrokerID);
            Console.WriteLine("AccountID: " + foo2.AccountID);
            Console.WriteLine("Packages table:");
            Console.WriteLine("  " + string.Join(", ", 
                foo2.Packages.Columns
                    .Cast<DataColumn>()
                    .Select(c => c.ColumnName + " (" + c.DataType.Name + ")")));
            foreach (DataRow row in foo2.Packages.Rows)
            {
                Console.WriteLine("  " + string.Join(", ", row.ItemArray
                    .Select(v => v != null ? v.ToString() : "(null)")));
            }
        }
    }
    class Foo
    {
        public string BrokerID { get; set; }
        public string AccountID { get; set; }
        public DataTable Packages { get; set; }
    }
