    var CardCount = new int[13];
    for (int k = 0; k < 5; k++)
    {
        CardCount[PokerCard[k] % 13]++;
    }
    for (int c = 0; c < 12; c++)
    {
        if (CardCount[c] >= 2)
        {
            //do winning stuff
        }
    }
