    enum Suit : uint
    {
        Club = 0,
        Heart,
        Spade,
        Diamond
    }
    class Card
    {
        public int
            Value;
        public Suit
            Suit;
        public System.Drawing.Image GetImage()
        {
            return System.Drawing.Image.FromStream(
                global::cardLibraryProject.Properties.Resources.ResourceManager.GetStream(string.Format("card_{0}_{1}", this.Suit, this.Value))
            );
        }
    }
    class Deck
    {
        System.Collections.ArrayList
            _arr;
        private Deck()
        {
            this._arr = new System.Collections.ArrayList(52);
        }
        void Add(Card crd)
        {
            if (!this._arr.Contains(crd))
                this._arr.Add(crd);
        }
        public void Shuffle()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            System.Collections.ArrayList tmp1 = new System.Collections.ArrayList(this._arr);
            System.Collections.ArrayList tmp2 = new System.Collections.ArrayList(52);
            while (tmp1.Count > 0)
            {
                int idx = rnd.Next(tmp1.Count);
                tmp2.Add(tmp1[idx]);
                tmp1.RemoveAt(idx);
            }
            this._arr = tmp2;
            tmp1.Clear();
            tmp2.Clear();
        }
        public static Deck CreateDeck()
        {
            Deck newDeck = new Deck();
            for (int s = 0; s < 4; s++)
                for (int i = 0; i < 13; i++)
                    newDeck.Add(new Card { Value = i, Suit = (Suit)s });
            return newDeck;
        }
    }
    class Program
    {
        public void Main(string[] args)
        {
            Deck cards = Deck.CreateDeck();
            cards.Shuffle();
            pictureBox1.Image = cards[0].GetImage();
            // code to play game would go here.  Obviously, if you took
            // my suggestion about creating a "Cards" library, then you
            // wouldn't have a "void Main" at all, and this would
            // all go in the application that was the actual game.
        }
    }
