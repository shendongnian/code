    public class Cell
    {
        public Cell(int col, int row)
        {
            Column = col;
            Row = row;
        }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int[] Position
        {
            get { return new[] { Column, Row }; }
        }
    }
