    //Original string
    string values = "C 14 C 13 C 12 C 11 C 10";
    //this line will split your string in an array and will take out empty values if exists
    var split = values.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray(); ;
        
    List<Card> cards = new List<Card>();
    string card= string.Empty;
    
        for (int i = 0; i < split.Count() - 1; i += 2)
        {
            cards.Add(new Card() { Value = int.Parse(split[i + 1]), Suit = split[i] });
        }
