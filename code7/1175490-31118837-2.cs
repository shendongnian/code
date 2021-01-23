    public class MyItem
    {
        public string ID;
        public List<Tuple<string, string>> Properties;
        public override string ToString()
        {
            return string.Join(", ", Properties
                .Select(p => string.Format("{0} = {1}",
                    p.Item1,
                    p.Item2 ?? "(null)")));
        }
    }
