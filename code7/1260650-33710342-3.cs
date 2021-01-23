    class Program
    {
        static void Main()
        {
            UserList userList = new UserList();
            string addAnother = "y";
            while (addAnother == "y" || addAnother == "Y")
            {
                Console.WriteLine("Please enter a name: ");
                User user = new User(Console.ReadLine());
                userList.Add(user);
                Console.WriteLine("Do you want to add another user? (y)");
                addAnother = Console.ReadLine();
            }
            userList.GetUsers();
            Console.ReadKey();
        }
    }
