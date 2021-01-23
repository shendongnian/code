    class Program
    {
        static void Main(string[] args)
        {
            var res = InputCheck("Piotr", "Wolkowski");
            ValidInputSwitch((CheckInput)res);
            Console.ReadLine();
        }
        public static int InputCheck(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return (int)CheckInput.No_First_Name;
            }
            return (int)CheckInput.OK;
        }
        public static void ValidInputSwitch(CheckInput status)
        {
            do
            {
                switch (status)
                {
                    case CheckInput.No_First_Name:
                        Console.WriteLine("Please enter your first name.");
                        break;
                    case CheckInput.No_Last_Name:
                        Console.WriteLine("Please enter your last name.");
                        break;
                    case CheckInput.No_Password:
                        Console.WriteLine("Please enter your password.");
                        break;
                    case CheckInput.Wrong_Password:
                        Console.WriteLine("Your passwords do not match!");
                        break;
                    case CheckInput.OK:
                        Console.WriteLine("OK");
                        break;
                    default:
                        break;
                }
            }
            while (status != CheckInput.OK);
        }
    }
