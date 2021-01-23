    var rnd = new Random(); 
  
    for (int i = 0; i < exit; i++)
    {
        var ticket = rnd.Next();
        Console.WriteLine("Wellcome Mr.Nissan. The winning numbers for Lotto max are:");
        Console.WriteLine(ticket);
    }
