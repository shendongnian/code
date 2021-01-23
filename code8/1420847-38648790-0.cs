    public class Letter<T>
    {
        public char Letter {get;set;}
        public T Item {get;set;} /*or make this protected and expose it in your derived class */
    }
    public class LetterPoint : Letter<Point>
    {
        public LetterPoint(char c = ' ', int row = 0, int col = 0)
        {
            Letter = c;
            Item = new Point(row, col);
        }
        public string PositionToString => $"(X:{Item.X}Y:{Item.Y})";
        public override string ToString() => $"(LETTER:{Letter}, POSITION:{PositionToString})";
    }
    public class LetterScore : Letter<int>
    {
        public LetterScore(char c = ' ', int score = 0)
        {
            Letter = c;
            Item = score;
        }
        public override string ToString() => $"LETTER:{Letter}, SCORE:{Item}";
    }
