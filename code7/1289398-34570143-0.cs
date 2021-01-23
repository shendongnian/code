    class TwoWayDictionary<T1, T2>
    {
    	IDictionary<T1, T2> dic1 = new Dictionary<T1, T2>();
    	IDictionary<T2, T1> dic2 = new Dictionary<T2, T1>();
    
    	public T2 this[T1 key]
    	{
    		get
    		{
    			return dic1[key];
    		}
    		set
    		{
    			dic1[key] = value;
    			dic2[value] = key;
    		}
    	}
    
    	public T1 this[T2 key]
    	{
    		get
    		{
    			return dic2[key];
    		}
    		set
    		{
    			dic2[key] = value;
    			dic1[value] = key;
    		}
    	}
    
    	public void Remove(T1 key)
    	{
    		var value = dic1[key];
    		dic1.Remove(key);
    		dic2.Remove(value);
    	}
    
    	public void Remove(T2 key)
    	{
    		var value = dic2[key];
    		dic2.Remove(key);
    		dic1.Remove(value);
    	}
    }
