    class Program
    {
        static private authenticator auth = new authenticator();
    
        static void Main(string[] args)
        {
           string login = "hello"; 
           string pass = "12345";
           
           if(auth.CheckPassword(login, pass))
             Console.Write("Access granted");
           else Console.Write("Wrong login or password");
        }
    }
