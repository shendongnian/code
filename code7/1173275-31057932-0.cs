    public class Collection<T>
    {
    	private System.Collections.Generic.List<T> objects = new System.Collections.Generic.List<T>();
    	private System.Collections.Generic.List<string> keys = new System.Collections.Generic.List<string>();
    
    	public void Add(T newObject, string key = "", object before = null, object after = null)
    	{
    		if (after != null)
    		{
    			if (after as string != null)
    				SafeInsert(newObject, keys.IndexOf(after as string) + 1, key);
    			else
    				SafeInsert(newObject, (int)after, key);
    		}
    		else if (before != null)
    		{
    			if (before as string != null)
    				SafeInsert(newObject, keys.IndexOf(before as string), key);
    			else
    				SafeInsert(newObject, (int)before - 1, key);
    		}
    		else
    			SafeInsert(newObject, objects.Count, key);
    	}
    
    	private void SafeInsert(T newObject, int index, string key)
    	{
    		try
    		{
    			objects.Insert(index, newObject);
    			keys.Insert(index, key);
    		}
    		catch (Exception e)
    		{
    			throw e;
    		}
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
    		SafeRemove(keys.IndexOf(key));
    	}
    
    	public void Remove(int positionOneBased)
    	{
    		SafeRemove(positionOneBased - 1);
    	}
    
    	private void SafeRemove(int index)
    	{
    		try
    		{
    			objects.RemoveAt(index);
    			keys.RemoveAt(index);
    		}
    		catch (Exception e)
    		{
    			throw e;
    		}
    	}
    
    	public T this[int positionOneBased]
    	{
    		get
    		{
    			try
    			{
    				return objects[positionOneBased - 1];
    			}
    			catch (Exception e)
    			{
    				throw e;
    			}
    		}
    	}
    
    	public T this[string key]
    	{
    		get
    		{
    			try
    			{
    				return objects[keys.IndexOf(key)];
    			}
    			catch (Exception e)
    			{
    				throw e;
    			}
    		}
    	}
    
    	public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    	{
    		return objects.GetEnumerator();
    	}
    }
