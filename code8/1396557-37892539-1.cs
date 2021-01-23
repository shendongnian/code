    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your email.");
        var userEmail = Console.ReadLine(); // implicitly typed as string
        var isValidEmail = IsValidEmail(userEmail); // implicitly typed as bool
        Console.WriteLine("Valid Email:{0}", isValidEmail);
    }
