    public class Values
    {
        public int ValID { get; set; }
        public string Type { get; set; }
    }
    public class Place
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Values Values { get; set; }
    }
    public class TestClass
    {
        static DataTable MakeTable()
        {
            var table = new DataTable();
            table.Columns.Add("America", typeof(Place));
            table.Columns.Add("Africa", typeof(Place));
            table.Columns.Add("Japan", typeof(Place));
            DataRow row = table.NewRow();
            row["America"] = JsonConvert.DeserializeObject<Place>(@"{""Id"":1,""Title"":""Ka""}");
            row["Africa"] = JsonConvert.DeserializeObject<Place>(@"{""Id"":2,""Title"":""Sf""}");
            row["Japan"] = JsonConvert.DeserializeObject<Place>(@"{""Id"":3,""Title"":""Ja"",""Values"":{""ValID"":4,""Type"":""Okinawa""}}");
            table.Rows.Add(row);    
            return table;
        }
        public static void Test()
        {
            var datatable = MakeTable();
            var objType = JArray.FromObject(datatable, JsonSerializer.CreateDefault(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })).FirstOrDefault(); // Get the first row            
            var js = objType.ToString(); 
            Debug.WriteLine(js); // Outputs abbreviated JSON as desired.
        }
    }
