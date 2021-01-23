    var json = "{\"dept\":\"HR\",\"data\":[{\"height\":5.5,\"weight\":55.5},{\"height\":5.4,\"weight\":59.5},{\"height\":5.3,\"weight\":67.7},{\"height\":5.1,\"weight\":45.5}]}";
    var foo = JsonConvert.DeserializeObject<RootObject>(json);
    // Check Values
    // var department = foo.dept;
    // foreach (var item in foo.data)
    // {
    //      var height = item.height;
    //      var weight = item.weight;
    // }
    public class Datum
    {
        public double height { get; set; }
        public double weight { get; set; }
    }
    public class RootObject
    {
        public string dept { get; set; }
        public List<Datum> data { get; set; }
    }
