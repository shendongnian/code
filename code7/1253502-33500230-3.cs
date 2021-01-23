    public static class DeckBuilder
    {
        public Deck Build(DeckType deckType)
        {
            var deck = new Deck();
            switch (deckType)
            {
                case DeckType.Standard:
                    deck.SuitName = "Suit";
                    deck.Cards = CreateStandardCards();
                    break;
                case DeckType.Special:
                    deck.SuitName = "Dragon";
                    deck.Cards = CreateSpecialCards();
                    break;
                default:
                    throw new ArgumentException("deckType");
            }
        }
    
        private IEnumerable<Card> CreateStandardCards()
        {
            var suits = new List<string> { "Hearts", "Clubs", "Diamonds", "Spades"  };
            var values = new List<string> { "One", "Two", "Three", "Four", "Five" };
            return CreateCards(suits, values);
        }
    
        private IEnumerable<Card> CreateSpecialCards()
        {
            var suits = new List<string> { "Ridgeback", "Fireball", "Shortsnout", "Horntail"  };
            var values = new List<string> { "Uno", "Dos", "Tres", "Quattro", "Cincz" };
            return CreateCards(suits, values);
        }
    
        private IEnumerable<Card> CreateCards(IEnumerable<string> suits, IEnumerable<string> values)
        {
            foreach (var suit in suits)
            foreach (var value in values)
                yield return new Card { Suit = suit, Value = value };
        }
    }
