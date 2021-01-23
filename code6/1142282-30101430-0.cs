    var model = new MyClass();
    //good
    //model.NotSupportedTypes = new Enum[] { MyEnum.a }
    //bad
    model.NotSupportedTypes = new Enum[] { SomeOtherEnum.a }
    var validTypes = model.NotSupportedTypes.All(n => n.GetType() == typeof(MyEnum));
