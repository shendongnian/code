    class Program
    {
        static void Main(string[] args)
        {
            var data = initData();
            var result = getGroupedData(data);
            var json = new Newtonsoft.Json.JsonSerializer
            {
                Formatting=Formatting.Indented
            };
            json.Serialize(Console.Out,result);
            Console.ReadKey();
        }
        private static object getGroupedData(DataTable dt)
        {
            var id = 1;
            var rows = dt.Rows.OfType<DataRow>(); //because for some reason DataRowCollection is not an IEnumerable<DataRow>
            var products = rows //the products, each defined by Name and Level
              .GroupBy(r => new { Name = r.Field<string>("Name"), Level = r.Field<int>("Level") })
              .Select(g => new
              {
                  Id = id++, //create the id
                  Name = g.Key.Name,
                  Level = g.Key.Level,
                  // select the parent and throw exception if there are more or less than one
                  Parent = g.Select(r => r.Field<string>("Parent")).Distinct().Single() 
              }).ToList();
            var results = products
              .Select(p => new //need a partial result first, containing the Global, Apac and Emea rows, if they exist
              {
                  Id = p.Id,
                  Name = p.Name,
                  // Assuming the Level of a child is Level of parent+1
                  Parent = products.FirstOrDefault(par => par.Name == p.Parent && par.Level + 1 == p.Level),
                  Global = rows.FirstOrDefault(r => r.Field<string>("Name") == p.Name && r.Field<int>("Level") == p.Level && r.Field<string>("Group") == "Global"),
                  Apac = rows.FirstOrDefault(r => r.Field<string>("Name") == p.Name && r.Field<int>("Level") == p.Level && r.Field<string>("Group") == "APAC"),
                  Emea = rows.FirstOrDefault(r => r.Field<string>("Name") == p.Name && r.Field<int>("Level") == p.Level && r.Field<string>("Group") == "EMEA")
              })
              .Select(x => new //create the final result
              {
                  Id = x.Id,
                  Name = x.Name,
                  ParentId = x.Parent==null? (int?)null :x.Parent.Id,
                  GlobalValue1 = x.Global == null ? (double?)null : x.Global.Field<double?>("Value1"),
                  GlobalValue2 = x.Global == null ? (double?)null : x.Global.Field<double?>("Value2"),
                  APACValue1 = x.Apac == null ? (double?)null : x.Apac.Field<double?>("Value1"),
                  APACValue2 = x.Apac == null ? (double?)null : x.Apac.Field<double?>("Value2"),
                  EMEAValue1 = x.Emea == null ? (double?)null : x.Emea.Field<double?>("Value1"),
                  EMEAValue2 = x.Emea == null ? (double?)null : x.Emea.Field<double?>("Value2")
              })
              .ToArray();
            return results;
        }
        private static DataTable initData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Group", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Level", typeof(int));
            dt.Columns.Add("Parent", typeof(string));
            dt.Columns.Add("Value1", typeof(double));
            dt.Columns.Add("Value2", typeof(double));
            dt.Columns.Add("RowID", typeof(int));
            dt.Rows.Add("Global", "Product1", 1, null, 10, 20, 1);
            dt.Rows.Add("APAC", "Product1", 1, null, 80, 90, 2);
            dt.Rows.Add("EMEA", "Product1", 1, null, 50, 70, 3);
            dt.Rows.Add("Global", "Product2", 2, "Product1", 100, 200, 1);
            dt.Rows.Add("APAC", "Product2", 2, "Product1", 800, 900, 2);
            dt.Rows.Add("EMEA", "Product2", 2, "Product1", 500, 700, 3);
            dt.Rows.Add("Global", "Product3", 3, "Product2", 10, 20, 1);
            dt.Rows.Add("APAC", "Product3", 3, "Product2", 80, 90, 2);
            dt.Rows.Add("Global", "Product4", 4, "Product3", 110, 120, 1);
            dt.Rows.Add("APAC", "Product4", 4, "Product3", 810, 190, 2);
            dt.Rows.Add("EMEA", "Product4", 4, "Product3", 510, 170, 3);
            return dt;
        }
    }
