    public class CellVM
    {
      public int SelectedValue { get; set; }
    }
	public class RowVM
	{
 	 	public RowVM()
  		{
    		Columns = new List<CellVM>();
  		}	
  		public RowVM(int columns)
  		{
			Columns = new List<CellVM>();
			for(int i = 0; i < columns; i++)
			{
				Columns.Add(new CellVM());
			}
  		}
  		public List<CellVM> Columns { get; set; }
	}
	public class MatrixVM
	{
  		public MatrixVM()
  		{
    		Rows = new List<RowVM>();
  		}
  		public MatrixVM(int columns, int rows)
  		{
			Rows = new List<RowVM>();
			for(int i = 0; i < rows; i++)
			{
				Rows.Add(new RowVM(columns));
			}
    		// initialize collection with the required number of rows
  		}
  		public List<RowVM> Rows { get; set; }
  		public IEnumerable<SelectListItem> Foos { get; set; }
	}
