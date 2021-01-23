    class Program
    {
        // All the words collected from the sample question phrases.
        private static string auxStr = @"Who is the Who are Who is that there Where is the Where do you Where are my 
            When do the When is his When are we Why do we Why are they always Why does he What is What is her What is the Which 
            drink did you Which Which is How do you How does he know the answer How can I learn many much often far tell say 
            explain answer for from with about on me he his him her hers your yours they theyr theyrs";
        private static List<string> aux = new List<string>();
        static void Main(string[] args)
        {
            // Build a list of auxiliary words.
            aux = auxStr.ToLower().Split(' ').Distinct().ToList();
            // Test the method to get a subject.
            var subject = GetSubject("Do you know where is Poland", aux);
            foreach(var s in subject)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
        private static List<string> GetSubject(string question, List<string> auxiliaries)
        {
            // Convert the question to a list of strings
            var listQuestion = question.ToLower().Split(' ').Distinct().ToList();
            
            // Remove from the question all the words 
            // that are in the list of auxiliary phrases
            var notAux = listQuestion.Where(w => !auxiliaries.Contains(w)).ToList();
            return notAux;
        }
    }
