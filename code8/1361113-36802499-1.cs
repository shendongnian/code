    private static void Main(string[] args)
    {
        var board = new Board(8,7);
        var random = new Random();
        while (true)
        {
            Console.WriteLine("Pick a column 1 -8");
            int move;
            if (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 8)
            {
                Console.WriteLine("Must enter a number 1-8.");
                continue;
            }
            if (!board.DropCoin(1, move-1))
            {
                Console.WriteLine("That column is full, pick another one");
                continue;
            }
            if (board.Winner == 1)
            {
                Console.WriteLine(board);
                Console.WriteLine("You win!");
                break;
            }
            if (board.IsFull)
            {
                Console.WriteLine(board);
                Console.WriteLine("Tie!");
                break;
            }
            var moves = new List<Tuple<int, int>>();
            for (int i = 0; i < board.Columns; i++)
            {
                if (!board.DropCoin(2, i))
                    continue;
                moves.Add(Tuple.Create(i, MinMax(6, board, false)));
                board.RemoveTopCoin(i);
            }
            int maxMoveScore = moves.Max(t => t.Item2);
            var bestMoves = moves.Where(t => t.Item2 == maxMoveScore).ToList();
            board.DropCoin(2, bestMoves[random.Next(0,bestMoves.Count)].Item1);
            Console.WriteLine(board);
            if (board.Winner == 2)
            {
                Console.WriteLine("You lost!");
                break;
            }
            if (board.IsFull)
            {
                Console.WriteLine("Tie!");
                break;
            }
        }
        Console.WriteLine("DONE");
        Console.ReadKey();
    }
    private static int MinMax(int depth, Board board, bool maximizingPlayer)
    {
        if (depth <= 0)
            return 0;
        var winner = board.Winner;
        if (winner == 2)
            return depth;
        if (winner == 1)
            return -depth;
        if (board.IsFull)
            return 0;
        int bestValue = maximizingPlayer ? -1 : 1;
        for (int i = 0; i < board.Columns; i++)
        {
            if (!board.DropCoin(maximizingPlayer ? 2 : 1, i))
                continue;
            int v = MinMax(depth - 1, board, !maximizingPlayer);
            bestValue = maximizingPlayer ? Math.Max(bestValue, v) : Math.Min(bestValue, v);
            board.RemoveTopCoin(i);
        }
        return bestValue;
    }
    public class Board
    {
        private readonly int?[,] _board;
        private int? _winner;
        private bool _changed;
            
        public Board(int cols, int rows)
        {
            Columns = cols;
            Rows = rows;
            _board = new int?[cols, rows];
        }
        public int Columns { get; }
        public int Rows { get; }
        public bool ColumnFree(int column)
        {
            return !_board[column, 0].HasValue;
        }
        public bool DropCoin(int playerId, int column)
        {
            int row = 0;
            while (row < Rows && !_board[column,row].HasValue)
            {
                row++;
            }
            if (row == 0)
                return false;
            _board[column, row - 1] = playerId;
            _changed = true;
            return true;
        }
        public bool RemoveTopCoin(int column)
        {
            int row = 0;
            while (row < Rows && !_board[column, row].HasValue)
            {
                row++;
            }
            if (row == Rows)
                return false;
            _board[column, row] = null;
            _changed = true;
            return true;
        }
        public int? Winner
        {
            get
            {
                if (!_changed)
                    return _winner;
                _changed = false;
                for (int i = 0; i < Columns; i++)
                {
                    for (int j = 0; j < Rows; j++)
                    {
                        if (!_board[i, j].HasValue)
                            continue;
                        bool horizontal = i + 3 < Columns;
                        bool vertical = j + 3 < Rows;
                        if (!horizontal && !vertical)
                            continue;
                        bool forwardDiagonal = horizontal && vertical;
                        bool backwardDiagonal = vertical && i - 3 >= 0;
                        for (int k = 1; k < 4; k++)
                        {
                            horizontal = horizontal && _board[i, j] == _board[i + k, j];
                            vertical = vertical && _board[i, j] == _board[i, j + k];
                            forwardDiagonal = forwardDiagonal && _board[i, j] == _board[i + k, j + k];
                            backwardDiagonal = backwardDiagonal && _board[i, j] == _board[i - k, j + k];
                            if (!horizontal && !vertical && !forwardDiagonal && !backwardDiagonal)
                                break;
                        }
                        if (horizontal || vertical || forwardDiagonal || backwardDiagonal)
                        {
                            _winner = _board[i, j];
                            return _winner;
                        }
                    }
                }
                _winner = null;
                return _winner;
            }
        }
        public bool IsFull
        {
            get
            {
                for (int i = 0; i < Columns; i++)
                {
                    if (!_board[i, 0].HasValue)
                        return false;
                }
                return true;
            }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int j = 0; j < Rows; j++)
            {
                builder.Append('|');
                for (int i = 0; i < Columns; i++)
                {
                    builder.Append(_board[i, j].HasValue ? _board[i,j].Value.ToString() : " ").Append('|');
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
