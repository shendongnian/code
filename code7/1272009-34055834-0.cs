    static void Main(string[] args)
        {
            string SalesPerson;
            int Sales = 0;
            //The loop to ask the user for a letter
            do
            {
                Console.WriteLine("Please enter the salesperons's initial");
                SalesPerson = Console.ReadLine().ToUpper();
                //If the letter is not equal to "A", repeat the prompt
                }while (SalesPerson != "A")
         
                if (SalesPerson=="A")
                {
                    Console.WriteLine("Please enter amount of a sale Andrea Made");
                    Sales = Convert.ToInt32(SalesPerson);
            }
        }
