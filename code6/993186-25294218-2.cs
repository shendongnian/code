    var list = new List<MyClass>();
    list.Add(new MyClass() {
       EnumValue = MyEnum.ValueZero | MyEnum.ValueOne, Property = "myClass1"
    });
    list.Add(new MyClass() {
       EnumValue = MyEnum.ValueZero | MyEnum.ValueOne, Property = "myClass2"
    });
    list.Add(new MyClass() {
       EnumValue = MyEnum.ValueOne , Property = "myClass3"
    });
    list.Add(new MyClass() {
       EnumValue = MyEnum.ValueOne | MyEnum.ValueTwo, Property = "myClass4"
    });
    
    var enumValues = Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>().ToArray();
    var grouped = list.SelectMany(
          o => enumValues
             .Where(flag => o.EnumValue.HasFlag(flag))
             .Select(v => new { o, v })
       )
       .GroupBy(t => t.v, t => t.o);
    foreach (IGrouping<MyEnum, MyClass> group in grouped)
    {                
       Console.WriteLine(group.Key.ToString() + ": " + string.Join(", ", group.Select(x=>x.Property)));
    }
