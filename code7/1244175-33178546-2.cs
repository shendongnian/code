        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a Password: ");
            var password = Console.ReadLine();
            Console.WriteLine(IsValid(password) ? "Valid Password" : "Invalid Password");
            Console.ReadLine();
        }
        public static bool IsValid(string password)
        {
            var numberOfDigits = 0;
            if (password.Length < 8) return false;
            foreach (var characterInPassword in password.ToCharArray())
            {
                if (!char.IsLetterOrDigit(characterInPassword))
                    return false;
                if (char.IsDigit(characterInPassword))
                    numberOfDigits++;
            }
            return numberOfDigits >= 2;
        }
