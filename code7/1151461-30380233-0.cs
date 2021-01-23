        static void Main(string[] args)
        {
            SiteBinding s = new SiteBinding();
            s.ip = new BindingIP("127.0.0.1:8080");
            s.type = new BindingType();
            WebSiteSettings sets = new WebSiteSettings();
            sets.credentials = new SiteCredential();
            sets.bindings = new List<SiteBinding>() {s};
            XmlSerializer ser = new XmlSerializer(sets.GetType());
            ser.Serialize(new System.IO.MemoryStream(),sets);
            Console.Read();
        }
