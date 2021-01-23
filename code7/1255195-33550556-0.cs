    [Serializable]
    public class CustomDictionary
    {
    	[SerializeField]
    	private List<CustomDictionaryItem> l;
    
    	public void Add (string key, UnityEngine.Object value)
    	{
    		l.Add (new CustomDictionaryItem (key, value));
    	}
    	public bool ContainsKey (string key)
    	{
    		return l.Any (sdi => sdi.Key == key);
    	}
    	
    	public bool Remove (string key)
    	{
    		return l.RemoveAll (sdi => sdi.Key == key) != 0;
    	}
    	public UnityEngine.Object this [string key] {
    		get {
    			if (ContainsKey (key))
    				return (UnityEngine.Object)l.First (sdi => sdi.Key == key).Value;
    			return null;
    		}
    		set {
    			if (ContainsKey (key)) {
    				CustomDictionaryItem item = l.First (sdi => sdi.Key == key);
    				item.Value = value;
    			} else
    				Add (key, value);
    		}
    	}
    	public List<string> Keys {
    		get {
    			return l.Select (sdi => sdi.Key).ToList ();
    		}
    	}
    	public List<UnityEngine.Object> Values {
    		get {
    			return l.Select (sdi => (UnityEngine.Object)sdi.Value).ToList ();
    		}
    	}
    
    	public List<CustomDictionaryItem>.Enumerator GetEnumerator() {
    		return l.GetEnumerator();
    	}
    }
