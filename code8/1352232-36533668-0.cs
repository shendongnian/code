    double UserInput = 0.0;  // <- You need to initialize before using it ...
    .....
    string stopInput = "N";
    while (stopInput != "Q"))
    {
       Console.WriteLine("");
       Console.WriteLine("Please enter a unit to convert, type 'Q' to cancel");
       stopInput = Console.ReadLine();
       if(stopInput == "Q")
          break;
       UserInput = Convert.ToDouble(stopInput);
       ....
    }
