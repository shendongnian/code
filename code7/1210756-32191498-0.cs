    public interface IExampleInterface { void DoSomething();}
    public class ExampleClass : IExampleInterface, IDisposable {
    
       private bool _switch = true;
    
       public void DoSomething() {
           // lets use something disposable
           if(_switch) { // is this what you mean by in an if statement??
              var stream = new System.IO.MemoryStream();
              try {
                  // do something with stream
              } finally {
                  stream.Dispose(); // call dispose!
              }
           }
       }
       private System.IO.FileStream fs; // class level field
       public void Dispose(){
          // dispose of class fields here that implement IDisposable
          if(fs != null)
             fs.Dispose();
          fs = null;
       }
    }
