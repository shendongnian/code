    static void Main(string[] args)
        {
            // THIS DATA WOULD BE IN YOUR DATABASE
            CreateMockData();
                        
            var userDetails = GetUserInfoByName("Anna");
            Console.WriteLine(userDetails);
            userDetails = GetUserInfoByName("Neeva");
            Console.WriteLine(userDetails);
            Console.ReadLine();
        }
