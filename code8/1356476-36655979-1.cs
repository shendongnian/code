    static int[] GetInput()
    {
        string input = Console.ReadLine();
        //validate input here..
        int x = input[0] - 'A'; //converts char to int
        int y = int.Parse(input.Substring(1)) - 1;
        return new int[]{ x, y };
    }
