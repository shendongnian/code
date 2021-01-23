    List<int> numbers = new List<int>();
    for (int i = 1; i <= 7; i++)
    {
        int coin1 = RandomFlip();
        int coin2 = RandomFlip();
        if (coin1 == coin2)
        {
            numbers.Add(coin1);
        }
    }
    string output = "";
    for(int i = 0; i < numbers.Count; i++)
    {
        output+=numbers[i].ToString();
        if (i < numbers.Count-1)
        {
            output+=", ";
        }
    }
