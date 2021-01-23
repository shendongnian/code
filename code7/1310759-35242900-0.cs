    int validChoices;
    do
    {
      Console.WriteLine("do some logic ......"); // replace this line with your chooseAttributePoints() method ...
      Console.Write("Do you accept these? Type 1 for Yes, Type 2 for No. If No you can choose again:  ");
      // read input until user gets it right and enters a valid number ...
      var areYouHappyWithChoices = Console.ReadLine();
      while (!int.TryParse(areYouHappyWithChoices, out validChoices) || validChoices < 1 || validChoices > 2)
      {
        Console.WriteLine("Please try again. Enter 1 for Yes and 2 for No");
        areYouHappyWithChoices = Console.ReadLine();
      }
    } while (validChoices != 1);
