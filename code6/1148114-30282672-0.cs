    public static class BoardExtensions
    {
        public class IterationElement<T>
        {
            protected T[,] Board { get; set; }
            public int XPos { get; protected set; }
            public int YPos { get; protected set; }
            public T Element
            {
                get { return Board[XPos, YPos]; }
                set { Board[XPos, YPos] = value; }
            }
            public IterationElement(T[,] board, int x, int y)
            {
                this.Board = board;
                this.XPos = x;
                this.YPos = y;
            }
        }
        public static IEnumerable<IterationElement<T>> ValidItems<T>(this T[,] board, int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (board[x, y] != null)
                    {
                        yield return new IterationElement<T>(board, x, y);
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var board = new string[64, 64];
            for (int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 64; y++)
                {
                    if (random.Next() % 2 == 0)
                    {
                        board[x, y] = "OK";
                    }
                }
            }
            foreach (var item in board.ValidItems(10, 15))
            {
                Console.WriteLine(string.Format("[{0},{1}]: {2}", item.XPos, item.YPos, item.Element));
            }
            Console.ReadKey(true);
        }
    }
