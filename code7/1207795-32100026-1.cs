    Configuration conf = new Configuration();
    conf.Transactions = new List<ConfigurationTransaction>();
    conf["foo"] = new ConfigurationTransaction { Type = "foo" };
    conf["bar"] = new ConfigurationTransaction { Type = "bar" };
    var xs = new XmlSerializer(typeof(Configuration));
    using (var fs = new FileStream("test.txt", FileMode.Create))
    {
        xs.Serialize(fs, conf);
    }
    Configuration conf2;
    using (var fs = new FileStream("test.txt", FileMode.Open))
    {
        conf2 = (Configuration)xs.Deserialize(fs);
    }
    foreach (var tran in conf2.Transactions)
        Console.WriteLine(tran.Type);
    Console.WriteLine(conf2["foo"].Type);
    Console.WriteLine(conf2["bar"].Type);
