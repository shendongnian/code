     public static List<string> UserUI()
        {
            List<string> accessCredentials = new List<string>();
            Console.WriteLine("Account Name: ");
            string accountName = Console.ReadLine();
            accessCredentials.Add(accountName);
            Console.WriteLine("Account Key: ");
            string accountKey = Console.ReadLine();
            accessCredentials.Add(accountKey);
            return accessCredentials;
        }
