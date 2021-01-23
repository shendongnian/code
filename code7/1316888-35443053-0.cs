    public class TestClass : BindableBase
    {
      private string name;
      public string Name
      {
        get { return this.name; }
        set { SetProperty(ref this.name, value); }
      }
  
      private string state;
      public string State
      {
        get { return this.state; }
        set { SetProperty(ref this.state, value); }
      }
    }
  
    public class YourClass : BindableBase  
    {
      public ObservableCollection<TestClass> InputDataCollection { get; set; }
      public string InputNameHeader { get; set;}
      public string InputStateHeader { get; set; }
      
      public YourClass()
      {
        // Test Data
        InputDataCollection = new ObservableCollection<TestClass>()
        {
          new TestClass() { Name = "Name1", State = "State1" },
          new TestClass() { Name = "Name2", State = "State2" }
        };
        InputNameHeader = "Name";
        InputStateHeader = "State";
      }
    }
