    public class TableVM
    {
      public TableVM()
      {
        Rows = new List<RowVM>();
      }
      public TableVM(int rows, int columns) : this()
      {
        for(int i = 0; i < rows; i++)
        {
          Rows.Add(new RowVM(columns));
        }
      }
      public List<string> Headers { get; set; } // for columns headers
      public List<RowVM> Rows { get; set; }
    }
    public class RowVM
    {
      public RowVM()
      {
        Cells = new List<CellVM>();
      }
      public RowVM(int columns) : this()
      {
        for(int i = 0; i < columns; i++)
        {
          Cells.Add(new CellVM());
        }
      }
      public List<CellVM> Cells { get; set; }
    }
    public class CellVM
    {
      public string Value { get; set; }
    }
