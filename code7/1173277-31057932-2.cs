    public class Collection<T>
    {
    	private System.Collections.Generic.List<T> objects = new System.Collections.Generic.List<T>();
    	private System.Collections.Generic.List<string> keys = new System.Collections.Generic.List<string>();
    
    	public void Add(T newObject, string key = null, object before = null, object after = null)
    	{
    		if (after != null)
    		{
    			if (after as string != null)
    				Insert(newObject, keys.IndexOf(after as string) + 1, key);
    			else
    				Insert(newObject, (int)after, key);
    		}
    		else if (before != null)
    		{
    			if (before as string != null)
    				Insert(newObject, keys.IndexOf(before as string), key);
    			else
    				Insert(newObject, (int)before - 1, key);
    		}
    		else
    			Insert(newObject, objects.Count, key);
    	}
    
    	private void Insert(T newObject, int index, string key)
    	{
   			objects.Insert(index, newObject);
   			keys.Insert(index, key);
    	}
    
    	public void Clear()
    	{
    		objects.Clear();
    		keys.Clear();
    	}
    
    	public bool Contains(string key)
    	{
    		return keys.Contains(key);
    	}
    
    	public int Count
    	{
    		get
    		{
    			return objects.Count;
    		}
    	}
    
    	public void Remove(string key)
    	{
    		RemoveAt(keys.IndexOf(key));
    	}
    
    	public void Remove(int positionOneBased)
    	{
    		RemoveAt(positionOneBased - 1);
    	}
    
    	private void RemoveAt(int index)
    	{
   			objects.RemoveAt(index);
   			keys.RemoveAt(index);
    	}
    
    	public T this[int positionOneBased]
    	{
    		get
    		{
   				return objects[positionOneBased - 1];
    		}
    	}
    
    	public T this[string key]
    	{
    		get
    		{
   				return objects[keys.IndexOf(key)];
    		}
    	}
    
    	public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    	{
    		return objects.GetEnumerator();
    	}
    }
