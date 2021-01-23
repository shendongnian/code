    class MyClass
    {
        public FilterType SomeProperty { get; set; } 
    }
    
    var myClass = JsonConvert.DeserializeObject<MyClass>(@"{""SomeProperty"":""unsafe""}");
    var itsUnsafe = myClass.SomeProperty == FilterType.@unsafe;
    Console.WriteLine(itsUnsafe);
