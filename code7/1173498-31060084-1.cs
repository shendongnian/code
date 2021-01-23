      Console.WriteLine("Type a lowercase letter.");
      char letter;
      Char.TryParse(Console.ReadLine(), out letter);
      while (letter != '!')
      {
        if (char.IsLower(letter))
        {
          Console.WriteLine("OK. Type another lowercase letter");
        }
        else
        {
          Console.WriteLine("Error");
        }
        Char.TryParse(Console.ReadLine(), out letter);
      }
