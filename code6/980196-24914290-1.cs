    public class Test2 {
       // initialize constructor here, but return compile-error
       static Test k = new Test();
       static void Main() {
           Console.Write(k.Rt());  // error here
       }
    }
