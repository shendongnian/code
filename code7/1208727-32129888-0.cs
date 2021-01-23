    List<int> results = new List<int>();
    for (int i = 1; i <= 7; i++)
    {
        int coin1 = RandomFlip(); //1 head 2 tails
        int coin2 = RandomFlip();
    
        if(coin1 == coin2)
        {
            results.Add(coin1);
        }
    }
    Console.WriteLine(string.Join(", ", results.Select(ToString));
