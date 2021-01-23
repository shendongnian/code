    public class PCE { }
    public class Board
    {
        readonly int size;
        readonly Dictionary<int, PCE> pieces;
        public Board(int size)
        {
            this.size=size;
            pieces=new Dictionary<int, PCE>();
        }
        public int Size { get { return size; } }
        public int GetKeyFromPosition(int i, int j) { return size*i+j; }
        public void GetPositionFromKey(int key, out int i, out int j)
        {
            i=key/size;
            j=key%size;
        }
        public void PlacePCE(int i, int j, PCE item)
        {
            pieces[size*i+j]=item;
        }
        public PCE GetPCE(int i, int j)
        {
            if (pieces.ContainsKey(size*i+j))
            {
                return pieces[size*i+j];
            }
            return null;
        }
        public PCE this[int i, int j]
        {
            get { return GetPCE(i, j); }
            set { PlacePCE(i, j, value); }
        }
        public bool IsLocationFilled(int i, int j)
        {
            return pieces.ContainsKey(size*i+j);
        }
        public List<KeyValuePair<int, PCE>> Pieces
        {
            get
            {
                return pieces.ToList();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Board board=new Board(64);
            board.PlacePCE(4, 7, new PCE());
            board.PlacePCE(11, 2, new PCE());
            board.PlacePCE(2, 47, new PCE());
            board.PlacePCE(51, 37, new PCE());
            if (board.IsLocationFilled(2, 47))
            {
                var pce=board[2, 47];
            }
            // Non-nulls only. Iterates over 4 items only
            foreach (var item in board.Pieces)
            {
                int i, j;
                board.GetPosition(item.Key, out i, out j);
                PCE pce=item.Value;
                // Do something with [i,j] PCE
            }
        }
    }
