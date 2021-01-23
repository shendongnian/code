    if (s2 == 2)
    {
        string temp = ""; 
        Console.WriteLine("Enter several sentences, when done entering" + 
                            " sentences, use q by itself on the last line:");
        string finalString = ""; // initial empty value
        while((temp = Console.ReadLine()) != "q") // assign input to temp and check its value
        {
            finalString += " " + temp; // temp was not `q` so append it to text.
        }
        Console.WriteLine(???); // explained later
    }
