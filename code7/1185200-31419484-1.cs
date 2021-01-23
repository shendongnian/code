     public static int[] GetRandomNumberCount()
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
        //This is where you would return a value, but in this case it seems you want to return an array of ints
        //Notice how I changed the return type of the method to Int[]
       int[] numbers = new int[4];
       numbers.Add(first);
       numbers.Add(second);
       numbers.Add(third);
       numbers.Add(fourth);
       
       //This is the actual return statement that your methods are missing
       return numbers;
        }
