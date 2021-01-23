    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Starting Encryption ***");
            Engine.StartEncryption("test.txt", "", "12345", Engine.ECB, 16);
        }
    }
