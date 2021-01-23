    Console.WriteLine("Enter one of you student's id number");
    
    userInput = Console.ReadLine();
    for (int i = 0; i < studentsid.length; i++)
    {
      if (studentsid[i].ToUpper() == userInput.ToUpper())
      {
          found = true;
          Console.WriteLine(mark[i]);                           
      }
    }
