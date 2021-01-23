    Dictionary<string, Card> d = new Dictionary<string, Card>();
    
    while ((s = sr.ReadLine()) != null)
    {
      string cardName = "card" + cardIndex.ToString();
      Card card = new Card(cardName, s);
      d.Add(s, card);
    }
