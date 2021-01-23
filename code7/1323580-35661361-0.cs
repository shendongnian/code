    public void PromptUser()  
    {
      Console.Write("Column Number (1 -7): ");
      int userInput = 0;
      while (userInput < 1 || userInput > 7)
      {
        String sInput = Console.ReadLine();
        bool bValid = int.TryParse(sInput, out userInput);
        If (!bValid || userInput < 1 || userInput > 7)
          Console.WriteLine("Invalid input. Please enter a number (1 - 7)");
      }
    ...
    }
