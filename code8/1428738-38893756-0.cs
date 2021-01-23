    List<int> data = new List<int>();
    do
    {
        int nextUserCard = kartendeck.GetARandomCard();
        data.Add(nextUserCard)
        userDecision = Console.ReadLine();
        Console.WriteLine("You have: " + kartendeck.ReturnCardName(nextUserCard) + " V:" + kartendeck.ReturnCardValue(nextUserCard));
        Console.WriteLine(GET THE ADDED CARD VALUE)
        Console.WriteLine("Pick? y/n");
    } while (userDecision != "n");
    // here you can access data and loop through it or do whatever.
