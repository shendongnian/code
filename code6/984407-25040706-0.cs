    void Main()
    {
    	System.Console.SetOut(new CustomTextWriter());
    	
    	Console.WriteLine("test");
    }
    
    public class CustomTextWriter : TextWriter
    {
    	private TextWriter _consoleOut = null;
    	private Log _logger = null;
    
    	public CustomTextWriter()
    	{
    		_consoleOut = System.Console.Out;
    		_logger = new Log();
    	}
    	
    	public override void Write(char[] buffer, int index, int count)
        {
        	this.Write(new String(buffer, index, count));
    	}
    
        public override void Write(string value)
    	{
        	_consoleOut.Write(value);
    		_logger.Write(value);
    	}
    		
    	public override void WriteLine(string value)
    	{
    		_consoleOut.WriteLine(value);
    		_logger.WriteLine(value);
    	}
    
        public override Encoding Encoding
        {
        	get { return System.Text.Encoding.Default; }
        }
    }
