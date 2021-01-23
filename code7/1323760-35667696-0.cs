    static void Main()
    {
        var card = new Card();
        card.cells[3, 2] = true;
        Console.WriteLine(card.cells[2, 4]); // False
        Console.WriteLine(card.cells[3, 2]); // True
        logEnd();
    }
    public class Cells
    {
        List<bool> b = new List<bool>();
        public Cells()
        {
            for (int i = 0; i < 25; i++)
            {
                b.Add(false);
            }
        }
        public virtual bool this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= 5 || col < 0 || col >= 5) throw new Exception("Something");
                return b[row * 5 + col];
            }
            set
            {
                if (row < 0 || row >= 5 || col < 0 || col >= 5) throw new Exception("Something");
                b[row * 5 + col] = value;
            }
        }
    }
    public interface ICard
    {
        Cells cells { get; set; }
    }
    public class Card : ICard
    {
        Cells _cells = new Cells();
        public Cells cells { get { return _cells; } set { _cells = value; } }
    }
