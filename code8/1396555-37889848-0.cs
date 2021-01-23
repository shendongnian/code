    static void Main(string[] args)
    {
       Console.WriteLine("Please enter your email.");
       string UserEmail = Console.ReadLine();
       bool ValEmail = IsValidEmail(UserEmail); 
    
       Console.WriteLine("Valid Email:{0}", ValEmail);
    }
