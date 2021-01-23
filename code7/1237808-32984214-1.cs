     string inputVal = "";
     double inputDoubleVal;
     while (inputVal == "Exit")
       {
          Console.WriteLine("Enter value for Monday : ");
          inputVal = Console.ReadLine();
          if (double.TryParse(inputVal, out  inputDoubleVal))
           {
              //Process with your double value
           }
          else
           {
             Console.WriteLine("You entered an invalid number - a default of 0 has been set");
           }
       }
