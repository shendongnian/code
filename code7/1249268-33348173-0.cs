    string json = @"{""key1"":""value1"",""key2"":""value2""}";
    var o = new DataContractJsonSerializer(typeof(T));
    var mem = new MemoryStream(UTF32Encoding.UTF8.GetBytes(new StreamReader(json.ToCharArray()));
    mem.Position = 0;
    var o2 = o.ReadObject(mem);
    public class T
    {
        public string key1 { get; set; }
        public string key2 { get; set; }
    }
