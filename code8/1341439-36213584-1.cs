    HashSet<char> chars = new HashSet<char>();
    //User input
    Console.WriteLine("Please Enter 5 Letters only: ");
    for (int i = 0; i < 5; )
    {
         char c = Convert.ToChar(Console.ReadLine());
         if(!("abcdefghijklmnopqrstuvwxyz".Contains(c.ToString().ToLower())))
         {
              Console.WriteLine("Please enter an alphabet");
              continue;
         }
         else if (!chars.Contains(c))
         {
              chars.Add(c);
              i++;
         }
         else
         {
              Console.WriteLine("Duplicate value please try again");
              continue;
         }
    }
    //display
    Console.WriteLine("You have entered the following inputs: ");
    foreach(char c in chars)
        Console.WriteLine(c.ToString());
                
    Console.Read();
