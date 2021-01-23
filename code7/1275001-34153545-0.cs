    public class TestClass
    {
         private string _name = string.Empty;
    
         public string Name
         {
             get{ return _name; }
             private set { _name = value; }
         }
    
         public TestClass(string name)
         {
             this.Name = name;
         }
    }
