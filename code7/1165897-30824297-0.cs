    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task<string>>();
            tasks.Add(SafeGenerateXml());
            Task.WaitAll(tasks.ToArray());
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Result);
            }
            Console.WriteLine("finished");
            Console.ReadKey();
        }
        static async Task<string> SafeGenerateXml()
        {
            try
            {
                return await GenerateXml();
            }
            catch (Exception)
            {
                return "";
            }
        }
        static async Task<string> GenerateXml()
        {
            await Task.Delay(3000);
            return "my xml data";
        }
    }
