    public class Matrix<T> : ICloneable
    	where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
    	private readonly int _rows;
    	private readonly int _columns;
    	private readonly IList<T> _data;
    
    	public Matrix(int rows, int columns)
    	{
    		_rows = rows;
    		_columns = columns;
    		_data = new List<T>(Rows * Columns);
    	}
    
    	private Matrix(int rows, int columns, IList<T> data)
    	{
    		_rows = rows;
    		_columns = columns;
    		_data = new List<T>(data);
    	}
    
    	public int Rows
    	{
    		get { return _rows; }
    	}
    
    	public int Columns
    	{
    		get { return _columns; }
    	}
    
    	public T Element(int row, int column)
    	{
    		return _data[row * column];
    	}
    
    	public object Clone()
    	{
    		return new Matrix<T>(Rows, Columns, _data);
    	}
    }
