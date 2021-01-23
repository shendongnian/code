    int n;
    Console.WriteLine("How many town names would you like to enter:");
    n = int.Parse(Console.ReadLine());
    string[] TownNames = new string[n];
    Console.Clear();
    int totalLength = 0; // holds total length of names
    Console.WriteLine("Enter {0} town names:", n);
    for (int i = 0; i < n; i++)
    {
        Console.Write("Enter number {0}: ", i + 1);
        TownNames[i] = Convert.ToString(Console.ReadLine());
        totalLength += TownNames[i].Length; // add the name length to total
    }
    int average = totalLength/n; // calculate average
    Console.Clear();
    Console.WriteLine("town names lower than average length:");
    for (int i = 0; i < n; i++)
    {
        if (TownNames[i].Length < average) // print values when the length name is less than average.
        {
            Console.WriteLine("Town {0} : {1}", i + 1, TownNames[i]);
        }
    }
    Console.ReadKey(true);
