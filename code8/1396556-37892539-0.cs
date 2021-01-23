    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your email.");
        var UserEmail = Console.ReadLine(); // implicitly typed as string
        var ValEmail = IsValidEmail(UserEmail); // implicitly typed as bool
        Console.WriteLine("Valid Email:{0}", ValEmail);
    }
