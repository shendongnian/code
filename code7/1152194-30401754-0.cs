    [Serializable]
    public struct TestStruct
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Value3 { get; set; }
    }
    TestStruct s1 = new TestStruct();
    s1.Value1 = 43265;
    s1.Value2 = 2346;
    s1.Value3 = "SE";
    string serialized = jss.Serialize(s1);
    s2 = jss.Deserialize<TestStruct>(serialized);
    Console.WriteLine(serialized);
    Console.WriteLine(s2.Value1 + " " + s2.Value2 + " " + s2.Value3);
