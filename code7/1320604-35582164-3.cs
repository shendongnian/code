    static void Main(string[] args)
    {
        var data = new List<Data>
        {
            new Data("Food", "1_g", "beverage", "2_b", "hot", "3_h"),
            new Data("Food", "1_g", "beverage", "2_b", "cold", "3_c"),
            new Data("Food", "1_g", "fruit", "2_f", "juicy", "3_j"),
            new Data("Food", "1_g", "fruit", "2_f", "solid", "3_s"),
            new Data("Food", "1_g", "cookie", "2_c", "chocolate", "3_cho"),
        };
        var tree = from l1 in data
                    group l1 by new { key = l1.Key_L1, name = l1.L1 } into group1
                    select new
                    {
                        key = group1.Key.key,
                        name = group1.Key.name,
                        children = from l2 in group1
                                    group l2 by new { key = l2.Key_L2, name = l2.L2 } into group2
                                    select new
                                    {
                                        key = group2.Key.key,
                                        name = group2.Key.name,
                                        children = from l3 in group2
                                                    select new { key = l3.Key_L3, name = l3.L3 }
                                    }
                    };
        var serializer = new JavaScriptSerializer();
        Console.WriteLine(serializer.Serialize(tree));
        Console.ReadLine();
    }
    class Data
    {
        public Data(string l1, string k1, string l2, string k2, string l3, string k3)
        {
            L1 = l1; Key_L1 = k1;
            L2 = l2; Key_L2 = k2;
            L3 = l3; Key_L3 = k3;
        }
        public string L1 { get; set; }
        public string Key_L1 { get; set; }
        public string L2 { get; set; }
        public string Key_L2 { get; set; }
        public string L3 { get; set; }
        public string Key_L3 { get; set; }
    }
