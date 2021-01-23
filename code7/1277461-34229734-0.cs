    using Newtonsoft.Json;
    using System.Linq;
    Dictionary<string, string> tt = JsonConvert.DeserializeObject<List<DataObject>>(@"[{""Id"":""1"",""Name"":""Apple ""},{""Id"":""2"",""Name"":""Orange ""},{""Id"":""3"",""Name"":""Banana ""}]").ToDictionary(k => k.Id, v => v.Name);
    public class DataObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
