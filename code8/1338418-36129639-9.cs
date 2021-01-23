    public class Info
    {
        public string tag { get; set; }
        public string value { get; set; }
        public string reference { get; set; }
    }
    public class StockChecklist
    {
        private Dictionary<string, Info> _infoDict = new Dictionary<string, Info>();
        private void AddToDict(Info info)
        {
            _infoDict.Add(info.tag, info);
        }
        public StockChecklist2()
        {
            AddToDict(new Info { tag = "uniqueval23456", value = "", reference = "" });
            AddToDict(new Info { tag = "uniqueval3736", value = "", reference = "" });
            AddToDict(new Info { tag = "uniqueval97357", value = "", reference = "" });
            AddToDict(new Info { tag = "uniqueval88356", value = "", reference = "" });
            AddToDict(new Info { tag = "uniqueval62346", value = "", reference = "" });
            AddToDict(new Info { tag = "uniqueval09876", value = "", reference = "" });
            AddToDict(new Info { tag = "uniqueval62156", value = "", reference = "" });
            AddToDict(new Info { tag = "uniqueval25326", value = "", reference = "" });
        }
        public bool TryGetByTag(string tag, out Info info)
        {
            return _infoDict.TryGetValue(tag, out info);
        }
        public Info this[string tag]
        {
            get
            {
                Info info;
                if (!_infoDict.TryGetValue(tag, out info))
                    return null;
                return info;
            }
        }
    }
