    var count = 0;
    do
    {
       Console.Write("\n\nUser Input:");
       int user_input;
       if ((int.TryParse(Console.ReadLine(), out user_input) == false) || (user_input < 0 || user_input > 5))
       {
          Console.WriteLine("Error : the action entered is not a valid number.");
          count = 0;
       }
       else
          count = 1;
    } 
    while (count != 1);
