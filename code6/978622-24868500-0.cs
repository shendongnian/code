    ConsoleKeyInfo keyInfo;
    do {
        Console.Write("Enter a number to compare; press the 'p' key to quit: ");
        keyInfo = Console.ReadKey(false);
        int c;
        if (Int32.TryParse(keyInfo.KeyChar.ToString(), out c))
        {    
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == c)
                {
                    pos.Add(j);
                }
            }          
    
            if (pos.Count == 0)
            {
                Console.WriteLine("Sorry this number does not match");
            }
            else
            {
               Console.WriteLine("The number {0} appears {1} time(s)",c,pos.Count);
            }
    } while (keyInfo.Key != ConsoleKey.P)
