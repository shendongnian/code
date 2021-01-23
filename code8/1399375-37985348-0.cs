    [DataMember]
    public Dictionary<int, dynamic> sub { get; set; }
    MyClass c = new MyClass() { ID = 1, Text = "Hello", sub = new Dictionary<int, dynamic>() };
    MyClass2 c2 = new MyClass2() { ID2 = 2, Text2 = "sub1" };
    c.sub.Add(1, c2);
    MyClass3 c3 = new MyClass3() { ID3 = 3, Text3 = "sub3" };
    c.sub.Add(2, c3);
....
    MyClass o = JsonConvert.DeserializeObject<MyClass>(File.ReadAllText(file));
    var Text2= o.sub[1].Text2;
    var Text3= o.sub[2].Text3;
