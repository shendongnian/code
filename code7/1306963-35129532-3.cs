    public class Person
    {
    	public string Name { get; set; }
    	public int Age { get; set; }
    	private List<Person> _children = null;
    	public List<Person> Children
    	{
    		get
    		{
    			if (_children == null)
    			{
    				_children = new List<Person>();
    			}
    			return _children;
    		}
    		set
    		{
    			_children = value;
    		}
    	}
    }
