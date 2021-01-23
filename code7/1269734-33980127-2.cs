	public class Card
    {
        public suits suit { get; set; }
        public cardValues cardValue { get; set; }
		public override string ToString()
		{
			return String.Format("Suit: {0}, Value: {1}", this.suit, this.cardValue);
		}
    }
	
	//in newDeck():
	
	var card = new Card() { suit = (suits)i, cardValue = (cardValues)j };
	Console.WriteLine(card);  //this is where you have a bug
	cards.Add(card);
	Console.ReadLine()
