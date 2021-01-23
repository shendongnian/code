    public class A
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public A() { }
        public A(string s)
        {
            string[] vals = s.Split((new string[] { "\r\n" }), StringSplitOptions.RemoveEmptyEntries);
            this.Id = vals[0].Replace("Id : ", string.Empty).Trim();
            this.Value = vals[1].Replace("Value : ", string.Empty).Trim();
        }
        public A(string id, string val)
        {
            this.Id = id;
            this.Value = val;
        }
        // only overridden here for printing
        public override string ToString()
        {
            return string.Format("Id : {0}\r\nValue : {1}\r\n", this.Id, this.Value);
        }
    }
    public static List<A> GetValuesRegEx(string file)
    {
        List<string> vals = new List<string>(Regex.Split(System.IO.File.ReadAllText(file), "--------------------"));
        vals.RemoveAll(delegate(string s) { return string.IsNullOrEmpty(s.Trim()); });
        List<A> ret = new List<A>();
        vals.ForEach(delegate(string s) { ret.Add(new A(s)); });
        return ret;
    }
    public static List<A> GetValuesXml(string file)
    {
        List<A> ret = new List<A>();
        System.Xml.Serialization.XmlSerializer srl = new System.Xml.Serialization.XmlSerializer(ret.GetType());
        System.IO.FileStream f = new System.IO.FileStream(file,
                                                          System.IO.FileMode.OpenOrCreate,
                                                          System.IO.FileAccess.ReadWrite,
                                                          System.IO.FileShare.ReadWrite);
        ret = ((List<A>)srl.Deserialize(f));
        f.Close();
        return ret;
    }
    public static List<A> GetValues(string file)
    {
        List<A> ret = new List<A>();
        List<string> vals = new List<string>(System.IO.File.ReadAllLines(file));
        for (int i = 0; i < vals.Count; ++i) {
            if (vals[i].StartsWith("---") && ((i + 3) < vals.Count) && (vals[i + 3].StartsWith("---"))) {
                ret.Add(new A(vals[i + 1].Replace("Id : ", string.Empty), vals[i + 2].Replace("Value : ", string.Empty)));
                i += 3;
            }
        }
        return ret;
    }
    public static void Main()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        for (int x = 0; x < 5; ++x) {
            double avg = 0d;
            for (int i = 0; i < 100; ++i) {
                sw.Restart();
                List<A> txt = GetValuesRegEx(@"C:\somefile.txt");
                sw.Stop();
                avg += sw.Elapsed.TotalSeconds;
            }
            Console.WriteLine(string.Format("avg: {0} s", (avg / 100)));
            // avg: 0.002429262 s (best average out of 5)
            sw.Stop();
            for (int i = 0; i < 100; ++i) {
                sw.Restart();
                List<A> txt = GetValuesXml(@"C:\somefile.xml");
                sw.Stop();
                avg += sw.Elapsed.TotalSeconds;
            }
            Console.WriteLine(string.Format("avg: {0} s", (avg / 100)));
            // avg: 0.004492328 s (best average out of 5)
            sw.Stop();
            for (int i = 0; i < 100; ++i) {
                sw.Restart();
                List<A> xml = GetValues(@"C:\somefile.xml");
                sw.Stop();
                avg += sw.Elapsed.TotalSeconds;
            }
            Console.WriteLine(string.Format("avg: {0} s", (avg / 100)));
            // avg: 0.005634914 s (best average out of 5)
        }
        sw.Stop();
    }
