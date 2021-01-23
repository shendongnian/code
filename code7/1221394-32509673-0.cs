    public static class Helper
    {
        public static void Load<TK, TV>(this Dictionary<TK, TV> dic, Stream stream)
        {
            var reader = new XmlSerializer(typeof (List<Entry<TK, TV>>));
            var list = (List<Entry<TK, TV>>)reader.Deserialize(stream);
            foreach(var l in list)
                dic.Add(l.Key,l.Value);
        }
        public static void Save<TK, TV>(this Dictionary<TK, TV> dic, Stream stream)
        {
            var list = new List<Entry<TK, TV>>();
            foreach (var pair in dic)
                list.Add(new Entry<TK, TV> {Key = pair.Key, Value = pair.Value});
            var writer = new XmlSerializer(typeof(List<Entry<TK, TV>>));
            writer.Serialize(stream, list);
        }
        public static void Load<TK, TV>(this Dictionary<TK, TV> dic, string path)
        {
            using(var f=File.OpenRead(path))
                Load(dic,f);
        }
        public static void Save<TK, TV>(this Dictionary<TK, TV> dic, string path)
        {
            using (var f = File.OpenWrite(path))
                Save(dic, f);
        }
    }
    public class Entry<TK, TV>
    {
        [XmlAttribute]
        public TK Key { get; set; }
        public TV Value { get; set; }
    }
