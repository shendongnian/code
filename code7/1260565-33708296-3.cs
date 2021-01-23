	List<User> _userList = new List<User>();
    static void Main(string[] args)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Address: ");
        string address = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        User user = new User(name, age, address, phone);
        _userList.Add(user);
    }
