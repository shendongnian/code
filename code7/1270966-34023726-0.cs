    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start");
    
                addAsync01(1, 2).Wait();
            }
            catch
            {
                //TODO
            }
            finally
            {
                Console.WriteLine("Finally");
                Console.ReadKey();
            }
            addAsync01(1, 2).Wait();
        }
    
        static async Task addAsync01(int sum1, int sum2)
        {
            int result = await AddAsync(sum1, sum2);
            Console.WriteLine("El resultado de sumar 1 y 2 es: " + result);
        }
    
        public static async Task<int> AddAsync(int num1, int num2)
        {
            return await Task.Run(() => num1 + num2);
        }
    }
