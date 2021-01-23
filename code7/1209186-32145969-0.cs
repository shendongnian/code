        private static void Main(string[] args)
        {
            // Declare a list of income taxes
            List<Taxpayer> incometax = new List<Taxpayer>();
            // Set the loop input
            bool moreInput = true;
            // Do the loop
            while (moreInput)
            {
                // Ask for the social security number
                Console.Write("Enter Social Security Number: ");
                string socialsecurity = Console.ReadLine();
                // Ask for income
                Console.Write("Enter Income: ");
                int income = Convert.ToInt32(Console.ReadLine());
                // Ask for the txt
                Console.Write("Enter Tax: ");
                int tax = Convert.ToInt32(Console.ReadLine());
                // Create a new taxpayer
                incometax.Add(new Taxpayer(socialsecurity, income, tax));
                // Ask if we should keep going?
                Console.Write("Add another? true/false: ");
                moreInput = Convert.ToBoolean(Console.ReadLine());
            }
            // Order the list by social security number
            Console.WriteLine("Sorted List:");
            incometax = incometax.OrderBy(x => x.SocialSecurityNumber).ToList();
            // Display each taxpayer
            foreach (Taxpayer taxPayer in incometax)
            {
                taxPayer.Display();
            }
            // Read any key to hold the console open
            Console.ReadKey();
        }
    }
    internal class Taxpayer
    {
        public Taxpayer(string socialsecurity, int income, int tax)
        {
            this.SocialSecurityNumber = socialsecurity;
            this.Income = income;
            this.Tax = tax;
        }
        public string SocialSecurityNumber { get; set; }
        public int Income { get; set; }
        public int Tax { get; set; }
        public int Amount
        {
            get
            {
                return this.Tax * this.Income;
            }
        }
        public void Display()
        {
            Console.WriteLine("SSN: {0} Income: {1} Tax: {2} Amout: {3}", this.SocialSecurityNumber, this.Income, this.Tax, this.Amount);
        }
    }
