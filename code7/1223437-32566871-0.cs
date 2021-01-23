    using System; 
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ForeverApp
    {
    
        class SomeObj
        {
            public void ExecuteForever()
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.Write(".");
                }
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                SomeObj so = new SomeObj();
    
                Thread thrd = new Thread(so.ExecuteForever);
    
                thrd.Start();
    
                Console.WriteLine("Exiting Main Function");
            }
        }
    }
