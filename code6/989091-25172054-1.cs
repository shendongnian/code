    public struct Test {
       public string str { get; set; }
       public int int1 { get; set; }
    }
    // This works:
    Test value = new Test();
    value.str = "asdf";
    value.int1 = 5;
    // But this does NOT work.
    Test TestProperty { get; set; }
    TestProperty.str = "asdf";
    TestProperty.int1 = 5;
