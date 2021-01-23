    int age = 0 ;
    if(int.TryParse(Console.ReadLine(), out age)
    {
    if (age >= 35)
      {
           Console.WriteLine("You are getting old");
      }
      else if (age <= 35)
      {
          Console.WriteLine("You are still young");
      }
      else
      {
           Console.WriteLine("Thats not an option!");
       }
    }
