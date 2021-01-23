    public class Example
    {
         private string demo;
         public class Example(string demo)
         {
              this.demo = demo;
         }
    
         public string Demo
         {
              get { return this.demo; }
              private set { this.demo = value; }
         }
    }
