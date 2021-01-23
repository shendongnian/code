    enum MyEnum
    {
      Value1 = 1,
      Value2 = 2
    }
    
      MyEnum e = MyEnum.Value1 | MyEnum.Value2;
      var isValid = Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>().Count(x => e.HasFlag(x)) == 1;
