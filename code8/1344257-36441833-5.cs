    public class MainWindowViewModel
    {
      /// <summary> This the object we want to be able to edit in the data grid. </summary>
      public ComplexObject BindingComplexObject { get; set; }
      public MainWindowViewModel()
      {
        BindingComplexObject = new ComplexObject();
      }
    }
    public class ComplexObject
    {
      public int ID { get; set; }
      public ObservableCollection<ComplexSubObject> Classes { get; set; }
      public ComplexObject()
      {
        ID = 1;
        Classes = new ObservableCollection<ComplexSubObject>();
        Classes.Add(new ComplexSubObject() { Name = "CustomFoo" });
        Classes.Add(new ComplexSubObject() { Name = "My Other Foo" });
      }
    }
    public class ComplexSubObject
    {
      public string Name { get; set; }
      public ObservableCollection<SimpleValues> Types { get; set; }
      public ComplexSubObject()
      {
        Types = new ObservableCollection<SimpleValues>();
        Types.Add(new SimpleValues() { name = "foo", value = "bar" });
        Types.Add(new SimpleValues() { name = "bar", value = "foo" });
      }
    }
    public class SimpleValues
    {
      public string name { get; set; }
      public string value { get; set; }
    }
