    class Program
    {
        static void Main(string[] args)
        {
            var _deck = new Stack<String>();
            _deck.Push("2h");
            _deck.Push("3h");
            _deck.Push("4h");
            _deck.Push("...");
            var first = _deck.Pop(); // ...
            first = _deck.Pop(); // 4h
        }
    }
