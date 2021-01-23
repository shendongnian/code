    class Suit
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
    
    var sorted = hand.OrderBy(x => x.suit.SortOrder).ThenBy(x => x.value);
