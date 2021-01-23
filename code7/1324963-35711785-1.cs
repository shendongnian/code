    public class Data
    {
        public string Id;
        public string Name;
        public bool AttachmentRequired;
        public string FormXml;
    }
    var o = JsonConvert.DeserializeObject<Data>(json);
    var xml = o.FormXml;
