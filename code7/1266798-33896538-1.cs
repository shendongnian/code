    namespace TestApplication
    {
        public class Program
        {
            public void Main(string[] args)
            {
                String filePath = args[0];
                Console.Write("The file you sent here: ");
                Console.WriteLine(filePath);
                Console.ReadLine();
            }
        }
    }
