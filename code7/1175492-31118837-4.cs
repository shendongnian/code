    public class MyItem
    {
        public string ID;
        public List<Tuple<string, string>> Properties;
        public string GetProperty(string name)
        {
            if (Properties == null)
                return null;
            var item = Properties.FirstOrDefault(x => x.Item1 == name);
            return item == null ? null : item.Item2;
        }
        public override string ToString()
        {
            return string.Join(", ", Properties
                .Select(p => string.Format("{0} = {1}",
                    p.Item1,
                    p.Item2 ?? "(null)")));
        }
    }
