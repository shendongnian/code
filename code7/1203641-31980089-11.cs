    public class Game
    {
        public List<Square> Squares { get; private set; }
        private Timer timer;
        private Random random = new Random();
        public Game()
        {
            this.Squares = Enumerable.Range(0, 9).Select(x => new Square {Value = SquareValue.Empty}).ToList();
            this.timer = new Timer(Callback, null, TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(10));
        }
        private void Callback(object state)
        {
            var sq = Squares[random.Next(0, 9)];
            var value = random.Next(0, 3);
            sq.Value = (SquareValue) value;
        }
    }
