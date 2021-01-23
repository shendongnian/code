    public class MyClass
    {
    	private List<string> backingField;
    	
    	public IReadOnlyCollection<string> MyStrings;
    	
    	public MyClass()
    	{
    		backingField = new List<string>();
    		MyStrings = backingField.AsReadOnly();
    	}
    	
    	public void AddString(string item)
    	{
    		backingField.Add(item);
    	}
    }
