    using System.ComponentMode;
    class MyClass()
    {
       [DefaultValue("SomeValue")]
       public string SomeProperty{ get; set; } = "SomeValue";
    }
    //
    var propertyInfo = typeof(MyClass).GetProperty("SomeProperty");
    var defaultValue = (DefaultValue)Attribute.GetCustomeAttribute(propertyInfo, typeof(DefaultValue));
    var value = defaultValue.Value;
