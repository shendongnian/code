    public class TextBox : Identifier
    {
        public string Label { get; set; }
    }
    
    public class CheckBox : Identifier
    {
    	
    }
    
    protected class Identifier
    {
    	public Guid Guid 
    	{
    		get; private set;
        }
    
        protected Identifier()
        {
        	Guid = new Guid();
        }
    }
