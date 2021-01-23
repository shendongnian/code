    string newJson = json.Replace("\"$val\":", "\"_val\":");
    Model[] models = JsonConvert.Deserialize<Model[]>(newJson);
    public class Model
    {
        public string _val { get; set; }
        public DateTime _exp { get; set; }
        public int _id { get; set; }
    }
