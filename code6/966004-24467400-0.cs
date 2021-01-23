    public class SudokuCell
    {
    	public bool IsEditable { get; set; }
    	private int _value;
    	public int Value 
    	{ 
    		get { return _value; }
    		set { if (IsEditable) _value = value; }
    }
