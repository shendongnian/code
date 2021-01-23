    public class Cell
    {
      public int Value { get; set; }
      public bool Flagged { get; set; }  // terrible name imho
    }
    public class Board
    {
      private List<List<Cell>> Rows;
      private List<List<Cell>> Columns;      
      public Board(IEnumerable<Cell> cells)
      {
        if (cells == null)
          throw new ArgumentNullException();
        if (cells.Count() != 25)
          throw new ArgumentException("cells must contain exactly 25 cells");
        // additional logic to make sure you don't have same values
        // or to many numbers in a specific range etc
        var orderedCells = cells.OrderBy(c => c.Value);
        Columns = new List<List<Cell>>()
        {
          orderedCells.Take(5).ToList(),
          orderedCells.Skip(5).Take(5).ToList(),  
          orderedCells.Skip(10).Take(5).ToList(),  
          orderedCells.Skip(15).Take(5).ToList(), 
          orderedCells.Skip(20).Take(5).ToList()  
        }
 
        Rows = Enumerable.Range(0,5)
          .Select(i => new List<Int>()
            {
              Columns.ElementAt(0).Skip(i).First(),
              Columns.ElementAt(1).Skip(i).First(),
              Columns.ElementAt(2).Skip(i).First(),
              Columns.ElementAt(3).Skip(i).First(),
              Columns.ElementAt(4).Skip(i).First(),
            })
          .ToList();
      }
      public IEnumerable<Cell> GetRow(int index)
      {
        if (index < 0 || index >= Rows.Count())
          throw new ArgumentOutOfRangeException();
        return Rows.ElementAt(index);
      }
      public IEnumerable<Cell> GetColumn(int index)
      {
        if (index < 0 || index >= Rows.Count())
          throw new ArgumentOutOfRangeException();
        return Rows.ElementAt(index);
      }
      public Cell GetCell(int column, int row)
      {
        if (column < 0 || column >= Columns.Count())
          throw new ArgumentOutOfRangeException();
        if (row < 0 || row >= Rows.Count())
          throw new ArgumentOutOfRangeException();
        return Rows.ElementAt(row).ElementAt(column);
      }
    }
