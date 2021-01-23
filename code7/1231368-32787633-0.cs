    static void Main(string[] args)
    {
        var phoneList = new List<string>();
        string input;
        Console.WriteLine("The Phone Number: ");
        while ((input = Console.ReadLine()) != "")
        {
            phoneList.Add(input);
        }    
        for (int i = 0; i < phoneList.Count; i++)
        {
            if (phoneList[i].Substring(0, 3) == "911")
            {
                Console.WriteLine("NOT CONSISTENT");
                return;
            }
        }
        Console.WriteLine("CONSISTENT");
    }
