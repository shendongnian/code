      ...
      MyDynamicClass c = new MyDynamicClass();
      c.MyStaticProperty = "hello";
    
      // build an object "type" from the original one
      DynamicTypeDescriptor dt = new DynamicTypeDescriptor(typeof(MyDynamicClass));
      // get a wrapped instance
      DynamicTypeDescriptor c2 = dt.FromComponent(c);
      // add a property named "MyDynamicProperty" of Int32 type, initial value is 1234
      c2.Properties.Add(new DynamicTypeDescriptor.DynamicProperty(dt, typeof(int), 1234, "MyDynamicProperty", null));
    
      propertyGrid1.SelectedObject = c2;
      ...
    
      // the class you want to "modify"
      public class MyDynamicClass
      {
          public string MyStaticProperty { get; set; }
      }
