    for (int tries = 0; tries == 0 || !Regex.IsMatch(item1.itemname.Trim(), @"^[A-Za-z]+$"); tries++)
    {
        if(tries > 0)
            Console.Write("Please enter Name in the Correct Format");
        Console.WriteLine("Please Enter the Item Name");
        item1.itemname = Console.ReadLine();
    }
