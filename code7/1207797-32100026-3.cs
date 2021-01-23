    Configuration conf = new Configuration();
    conf.Transactions = new List<PairHelper>();
    conf["fooTran"] = new ConfigurationTransaction { Type = "foo" };
    conf["barTran"] = new ConfigurationTransaction { Type = "bar" };
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
        Console.WriteLine(tran.TransactionName + " : " + tran.ConfigurationTransaction);
    Console.WriteLine(conf2["fooTran"].Type);
    Console.WriteLine(conf2["barTran"].Type);
