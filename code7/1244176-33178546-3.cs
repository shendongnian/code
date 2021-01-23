        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a Password: ");
            var password = Console.ReadLine();
            Console.WriteLine(IsValid(password) ? "Valid Password" : "Invalid Password");
            Console.ReadLine();
        }
        public static bool IsValid(string password)
        {
            var charactersInPassword = password.ToCharArray();
            if (charactersInPassword.Length < 8) return false;
            if (charactersInPassword.Any(character => !char.IsLetterOrDigit(character)))
                return false;
            var numberOfDigits = charactersInPassword.Count(char.IsDigit);
            return numberOfDigits >= 2;
        }
