    public class ParseMyDateItemList
    {
        public static void ParseString()
        {
            string x = "[{\"Name\":\"property1\",\"Value\":true},{\"Name\":\"FOO\",\"Value\":\"12345ddddeeee\"},{\"Name\":\"property3\",\"Value\":false}]";
            var dataItems = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<MyDataItem>>(x);
            var resultDataItems = dataItems.Except(dataItems.Where(t => t.Name.ToLower() == "foo")).ToList();
            var resultJson = Newtonsoft.Json.JsonConvert.SerializeObject(resultDataItems);
        }
    }
    public class MyDataItem
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
