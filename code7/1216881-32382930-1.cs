        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your date of birth in DD/MM/YYYY:");
            // Option 1.
            // The Console.ReadLine() function returns a string.
            string strDob = Console.ReadLine();
            DateTime? dob1 = strDob.Dob();
            
            // Option 2.
            // You can combine the two steps together into one line for smoother reading.
            DateTime? dob = Console.ReadLine().Dob();            
        }
    }
