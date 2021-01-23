    void Main()
    {
    	var items = new Items();
    	items.Add(1);
    	items.Add("foo");
    	items.Add(DateTime.Now);
    	items.Add('x');
    	
    	foreach (var item in items)
    	{
    		Console.WriteLine (item);
    	}
    }
    
    enum Kind
    {
    	Int,
    	String,
    	DateTime,
    	Char
    }
    
    class Items : IEnumerable<object>
    {
    	Stack<int> Ints = new Stack<int>();
    	Stack<string> Strings = new Stack<string>();
    	Stack<DateTime> DateTimes = new Stack<DateTime>();
    	Stack<char> Chars = new Stack<char>();
    	List<Kind> Kinds = new List<Kind>();
    	
    	IEnumerator<object> System.Collections.Generic.IEnumerable<object>.GetEnumerator()
    	{
    		foreach (var kind in Kinds)
    		{
    			switch (kind)
    			{
    				case Kind.Int:
    					yield return Ints.Pop();
    					break;
    				case Kind.String:
    					yield return Strings.Pop();
    					break;
    				case Kind.DateTime:
    					yield return DateTimes.Pop();
    					break;
    				case Kind.Char:
    					yield return Chars.Pop();
    					break;
    			}
    		}
    	}
    	
        IEnumerator	System.Collections.IEnumerable.GetEnumerator()
    	{
    		return (this as System.Collections.Generic.IEnumerable<object>).GetEnumerator();
    	}
    	
    	public void Add(int i)
    	{
    		Ints.Push(i);
    		Kinds.Add(Kind.Int);
    	}
    	
    	public void Add(string s)
    	{
    		Strings.Push(s);
    		Kinds.Add(Kind.String);
    	}
    	
    	public void Add(DateTime dt)
    	{
    		DateTimes.Push(dt);
    		Kinds.Add(Kind.DateTime);
    	}
    	
    	public void Add(char c)
    	{
    		Chars.Push(c);
    		Kinds.Add(Kind.Char);
    	}
    }
