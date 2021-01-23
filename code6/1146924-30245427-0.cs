    namespace Wip
    {
        class Program
        {
            static void Main(string[] args)
            {
                string prompt = "Please enter {0} integer between 1 and 100";
                string strNum;
                int num = 0;
                int i = 0;
                int sum =0 ;              
    
                do //ask once and repeat while 'while' condition is true
                {
                    string pluralPrompt = i > 0 ? "another" : "an";
                    prompt = string.Format(prompt,pluralPrompt);
                    Console.WriteLine(prompt); // asks for user input
                    strNum = Console.ReadLine();
                    if (!Int32.TryParse(strNum, out num)) //input is stored as num
                    {
                        // warn the user, throw an exception, etc.
                    }
                    sum += num; //add num to sum
                    i++; 
                    
                }
                while (num < 100);
                Console.WriteLine("No of integers entered is {0} {1}", i, sum); //output calculation 
                    
            }
        }
    }
