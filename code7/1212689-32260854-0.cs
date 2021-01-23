    public class CellVM
    {
      public int SelectedValue { get; set; }
    }
    public class RowVM
    {
      public RowVM()
      {
        Columns = new List<Cell>();
      }
      public RowVM(int columns)
      {
        // initialize collection with the required number of columns
      }
      public List<Cell> Columns { get; set; }
    }
    public class MatrixVM
    {
      public MatrixVM()
      {
        Rows = new List<RowVM>()
      }
      public MatrixVM(int columns, int rows)
      {
        // initialize collection with the required number of rows
      }
      public List<RowVM> Rows { get; set; }
      public IEnumerable<SelectListItem> Foos { get; set; }
    }
