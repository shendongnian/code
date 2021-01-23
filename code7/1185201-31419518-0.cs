    public static void GetRandomNumberCount()
    {
          //Create the secret code
          Random RandomClass = new Random();
    
          int first = RandomClass.Next(1, 5);
          int second = RandomClass.Next(1,5);
          int third = RandomClass.Next(1,5);
          int forth = RandomClass.Next(1,5);
    
          Console.WriteLine ("You are playing with M@sterB@t");
          Console.WriteLine ("Bot Says : You Go First");
          Console.WriteLine("Game Settings ");
          Console.WriteLine("The Game Begins");
    }
