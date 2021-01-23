    class class1 {
        public string string1{ set; get; }
        //code for class1
    }
    class class2 {
        class1 c1 = new class1();
        //then you can call it like this
        string test = c1.string1;
    }
