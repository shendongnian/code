    { public static decimal questions(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();
           
            decimal result;
            while (!decimal.TryParse(answer, out result))
            {
                Console.WriteLine(question);
                answer = Console.ReadLine();
            }
            return result;
    }
