    class Program
    {
        static void Main(string[] args)
        {
            Disposableclass obj; 
    
            for (int i = 0; i < 3; i++)
            {
                using (obj = new Disposableclass())
                { 
                }
            }
            /*for (int i = 0; i < 3; i++)
            {
                using (Disposableclass obj2 = new Disposableclass())
                { 
                }
            }*/
    
            Console.ReadKey();
        }
    
    }
    
    public class Disposableclass : IDisposable
    {
        public Disposableclass()
        {
            Console.WriteLine("Constructor called: " + this.GetType().ToString());
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose called: " + this.GetType().ToString());     
       }
    }
