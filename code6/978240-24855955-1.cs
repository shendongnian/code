    class Program
    {
        static void Main(string[] args)
        {
            var _deck = new Queue<String>();
            _deck.Enqueue("2h");
            _deck.Enqueue("3h");
            _deck.Enqueue("4h");
            _deck.Enqueue("...");
            var first = _deck.Dequeue(); // 2h
            first = _deck.Dequeue(); // 3h
        }
    }
   
