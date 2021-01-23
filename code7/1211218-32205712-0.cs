    enum MyOption { A, B, C }
    class MyClass
    {
        public MyOption Option { get; set; }
    }
    var obj = new MyClass();
    obj.Option = MyOption.A;
    if(obj.Option == MyOption.A)
    {
        // ...
    }
