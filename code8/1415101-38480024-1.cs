    Console.WriteLine("Loading cards from .txt file");
    using (StreamReader sr = new StreamReader(@"G:\Temp\cards.txt"))
    {
        string s;
        int cardIndex = 1;
        Dictionary<string, Card> d = new Dictionary<string, Card>();
    
        while ((s = sr.ReadLine()) != null)
        {
            string cardName = "card" + cardIndex.ToString();
            Card card = new Card(cardName, s);
            d.Add(s, card);
            cardIndex++;
        }
    }
