    static void Main()
    {
        var card = new Card();
        card.cells[3, 2] = true;
        Console.WriteLine(card.cells[2, 4]); // False
        Console.WriteLine(card.cells[3, 2]); // True
        Console.WriteLine(card.cells[8, 9]); // Exception
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
    public class Cells : List<bool>
    {
        public Cells()
        {
            for (int i = 0; i < 25; i++)
            {
                this.Add(false);
            }
        }
        public virtual bool this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= 5 || col < 0 || col >= 5) throw new IndexOutOfRangeException("Something");
                return this[row * 5 + col];
            }
            set
            {
                if (row < 0 || row >= 5 || col < 0 || col >= 5) throw new IndexOutOfRangeException("Something");
                this[row * 5 + col] = value;
            }
        }
    }
