    class Node
    {
        public Node(int number, Vector2 position)
        {
            this.Number = number;
            this.Position = position;
        }
        public int Number { get; private set; }
        public Vector2 Position { get; private set; }
    }
