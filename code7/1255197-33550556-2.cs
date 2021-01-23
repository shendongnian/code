    [Serializable]
    public class GenericDictionaryItem<K, V>
    {
    	[SerializeField]
    	private K m_key;
    	public K Key{ get { return m_key; } set { m_key = value; } }
    	[SerializeField]
    	private V m_value;
    	public V Value{ get { return m_value; } set { m_value = value; } }
    	public GenericDictionaryItem (K key, V value)
    	{
    		m_key = key;
    		m_value = value;
    	}
    
    	public GenericDictionaryItem () : this (default(K), default(V)) {
    	}
    
    	// In C# we cannot use non default constructor with types passed as generic argument.
    	// So as a workaround we will use this function instead of constructor.
    	internal void SetKV(K key, V value) {
    		m_key = key;
    		m_value = value;
    	}
    }
    [Serializable]
    // Generic arguments: K - key type, V - value type, Entry - must be a class derived from
    // GenericDictionaryItem<K, V> and implementing a default constructor.
    // K must implement Equals method!
    public class GenericDictionary<K, V, Entry> where Entry : GenericDictionaryItem<K, V>, new()
    {
    
    	[SerializeField]
    	private List<Entry > l;
    	
    	public void Add (K key, V value)
    	{
    		// Cannot use non default constructor with generic type.
    		// This is a workaround
    		var e = new Entry();
    		e.SetKV(key, value);
    
    		l.Add (e);
    	}
    	public bool ContainsKey (K key)
    	{
    		return l.Any (sdi => sdi.Key.Equals(key));
    	}
    	
    	public bool Remove (K key)
    	{
    		return l.RemoveAll (sdi => sdi.Key.Equals(key)) != 0;
    	}
    	public V this [K key] {
    		get {
    			if (ContainsKey (key))
    				return (V)l.First (sdi => sdi.Key.Equals(key)).Value;
    			return default(V);
    		}
    		set {
    			if (ContainsKey (key)) {
    				Entry item = l.First (sdi => sdi.Key.Equals(key));
    				item.Value = value;
    			} else
    				Add (key, value);
    		}
    	}
    	public List<K> Keys {
    		get {
    			return l.Select (sdi => sdi.Key).ToList ();
    		}
    	}
    	public List<V> Values {
    		get {
    			return l.Select (sdi => (V)sdi.Value).ToList ();
    		}
    	}
    	
    	public List<Entry>.Enumerator GetEnumerator() {
    		return l.GetEnumerator();
    	}
    }
    
    // Test class
    public class DictionaryTest : MonoBehaviour {
    
    	// Create dummy entry type
    	[Serializable]
    	public class Entry : GenericDictionaryItem<string, UnityEngine.Object> {
    	}
    
    	// Create dummy dictionary type
    	// Pay attention - we pass 3 arguments key type, value type and entry type
    	[Serializable]
    	public class MyDictionary : GenericDictionary<string, UnityEngine.Object, Entry> {
    	}
    
    	// And now we will see the dictionary in editor
    	public MyDictionary d;
    
    	void Start() {
    
    		d.Add("test1", null);
    		d.Add("test2", null);
    
    		Debug.Log(d.ContainsKey("test1"));
    		Debug.Log(d.ContainsKey("test2"));
    		Debug.Log(d.ContainsKey("test3"));
    	}
    }
