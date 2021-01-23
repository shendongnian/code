    public class TableVM
    {
      public List<RowVM> Rows { get; set; }
    }
    public class RowVM
    {
      public List<CellVM> Cells { get; set; }
    }
    public class CellVM
    {
      public string Value { get; set; }
    }
