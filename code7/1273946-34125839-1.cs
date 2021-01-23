    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ConsoleApplication1";
            string line;
            while ((line = PromptLine("Enter text: ")) != "")
            {
                Console.WriteLine("    Text entered: \"" + line + "\"");
            }
        }
        static string PromptLine(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
