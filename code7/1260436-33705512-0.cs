    List<string> list = new List<string>{"amelie", "barbon", "cat", "dog", "thomas"};
    int blacknumber = 3;
    do
    {
        list.RemoveAt(blacknumber < list.Count ? blacknumber : blacknumber - list.Count);
    } while (list.Count > 1);
    Console.WriteLine(list[0]); // prints barbon
