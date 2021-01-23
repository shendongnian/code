    public class Program
    {
       static void Main(string[] args)
       {
          while(true)
          {
            Method1();
            System.Threading.Thread.Sleep(TimeSpan.FromMinutes(5));
    
            Method2();
            System.Threading.Thread.Sleep(TimeSpan.FromMinutes(5));
          }
       }    
       private Method1()
       {
         Console.WriteLine("Method1 is executed at {0}", DateTime.Now);
       }
       private Method2()
       {
         Console.WriteLine("Method2 is executed at {0}", DateTime.Now);
       }
    }
