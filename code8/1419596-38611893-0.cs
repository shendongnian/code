    MyClass blub = new MyClass();
    
    var field = blub.GetType().GetField("myList1", BindingFlags.NonPublic | BindingFlags.Instance);
    List<MyStruct> value = field.GetValue(blub) as List<MyStruct>;
    
    if (value == null)
        value = new List<MyStruct>();
    
    value.Add(new MyStruct { foo = "foo", bar = "bar" });
    
    field.SetValue(blub, value);
