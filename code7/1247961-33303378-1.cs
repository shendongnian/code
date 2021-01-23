    public static void main(string[] args)
    {
      Console.WriteLine('Enter your username: ');
      string username = Console.ReadLine();
    
      Console.WriteLine('Enter your password: ');
      string password= Console.ReadLine();
    
      var logic = new MyLogic();
      logic.InitializeData();
      if(logic.Authenticate(username, password))
      {
        Console.WriteLine("Success")
      }
      else
      {
        Console.WriteLine("Fail");
      }
    }
