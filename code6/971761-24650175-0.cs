    public class RootObject
    {
         public RootObject() {
              this.MyProject = new MyProject();
         }
         public string UserToken { get; set; }
         public MyProject MyProject { get; set; }
    }
