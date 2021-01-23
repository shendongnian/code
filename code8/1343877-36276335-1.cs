    static void Main(string[] args)
            {
                string question = string.Empty;
                string answer = string.Empty;
                string formattedString = string.Empty;
                question = Console.ReadLine();
                Console.WriteLine("Replace ... with:");
                answer = Console.ReadLine();
                formattedString = question.Replace("... ", answer);
                Console.WriteLine(formattedString);
                Console.ReadLine();
            }
