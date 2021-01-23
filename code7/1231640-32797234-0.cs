    class Program
    {
        public static int correct_answer, counter,  user_answer;
        static void Main(string[] args)
        {
            correct_answer = 4;
            counter = 0;
            do 
            {
                
                counter++;
                Console.WriteLine("2+2= ?");
                user_answer = Convert.ToInt32(Console.ReadLine());
                if (user_answer != correct_answer)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong, try againg" + " this is your " + counterUpdated + " try.");
                }
            } while (user_answer != correct_answer); // The code will keep looping until the user prompts the correct answer 
            Console.Clear();
            Console.WriteLine("Well Done! you did it in this amount of guesses " + counter);
            Console.ReadLine();
        }
    }
