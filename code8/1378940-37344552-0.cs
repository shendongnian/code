    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var task = new Task<int>(() => 5);
                task.Start();
                task.Wait();
            }
        }
    }
