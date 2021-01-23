    class test {
        public int IntProperty { get; set; }
    }
    var ref1 = new test {
        IntProperty = 12
    };
    var ref2 = ref1;
    Console.WriteLine(ref1.IntProperty);
    Console.WriteLine(ref2.IntProperty);
    ref1.IntProperty = 15;
    Console.WriteLine(ref1.IntProperty);
    Console.WriteLine(ref2.IntProperty);
