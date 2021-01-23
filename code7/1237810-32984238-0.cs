    public int readInput(){
      int val = 0;
      Console.WriteLine("Enter a valid int");
      string enteredVal = Console.ReadLine();
      bool result = int.TryParse(enteredVal, out val);
      if(bool)
        return val;
      Console.writeLine("Try again, only int values allowed");
      return readInput();
    }
    
    int val = readInput();
