    class MyMutableTuple<T1, T2> {
        public T1 Item1 {get; set;}
        public T2 Item2 {get; set;}
    }
    var CValues = new MyMutableTuple<string, string>("abc", "def");
    CValues.Item1 = "ghi"; // Works!
