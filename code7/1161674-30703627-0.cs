    using System.Threading.Tasks;  
    public class Example
    {
       void StartOnDifferentThread()
       {
          Task.Factory.StartNew( () => { FunctionToRun(); } );
       }
    
       void FunctionToRun()
       {
          // do stuff
       }
    }
