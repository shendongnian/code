    namespace Lab1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string LabOne = "Hello World";
                for (int i = LabOne.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine(LabOne.ElementAt(i));
                    Console.ReadLine();
                }
            }
        }
    }
