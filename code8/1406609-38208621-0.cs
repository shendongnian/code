    static void Main(string[] args)
    {
        Land c = new Land();
        bool isCard = c.GetType().IsSubclassOf(typeof(Card));
    }
