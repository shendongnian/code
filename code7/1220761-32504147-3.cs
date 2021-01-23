    public class MyClass
    {
    	private List<string> backingField;
    	
    	public string Name { get; set; }
    	public IReadOnlyCollection<string> MyStrings { get; private set; }
    	
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
