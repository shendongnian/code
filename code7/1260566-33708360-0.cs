    class User
    {
        public User(string name)
        {
            Name = name;
        }
        public Name { get; private set; }
    }   
    public static void Main()
    {
        List<User> users = new List<User>();
        bool anotherUser = true;
        while (anotherUser)
        {
            Console.WriteLine("Please specify a name.");
            string userName = Console.ReadLine();
            User user = new User(userName);
            users.Add(user);
            string next = Console.WriteLine("Do you want to add another user (type Y for yes)?");
            anotherUser = (next == "Y");
        }
        Console.WriteLine("\nNames of added users:");
        foreach(User u in users)
        {
            Console.WriteLine(u.Name);
        }
        Console.ReadKey();
    }    
