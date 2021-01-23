    public class ExampleClass
    {
    	private string[] words = new string[] { "Word1", "Word2", "Word3", "Word4", "Word5" };
    
    	public bool this[string Word]
    	{
    		get { return words.Any(w => w == Word); }
    	}
    }
