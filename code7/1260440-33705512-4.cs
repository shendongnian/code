    List<string> list = new List<string>{"amelie", "barbon", "cat", "dog", "thomas"};
    int blacknumber = 3;
    blacknumber--; // because indexes are 0 based
    do
    {
        list.RemoveAt(blacknumber < list.Count ? blacknumber : blacknumber % list.Count);
    } while (list.Count > 1);
    Console.WriteLine(list[0]); // prints barbon
