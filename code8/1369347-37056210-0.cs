    public static int firstNumber()
    {
      int num01=0;
      if(!int.TryParse(Console.ReadLine(),out num01))
      {
        Greet("Invalid input");
      }
      return num01;
    }
