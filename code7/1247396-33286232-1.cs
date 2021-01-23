    class Authenticator
    {
        static void Main(string[] args)
        {
             Authenticator au = new Authenticator();
             au.InitialValues();
             if(au.Authenticate())
                Console.WriteLine("Authenticated");
             else
                Console.WriteLine("NOT Authenticated");
             Console.WriteLine("Press Enter to end");
             Console.ReadLine();
        }
        
        ..... the rest of your code ....
    
    }
