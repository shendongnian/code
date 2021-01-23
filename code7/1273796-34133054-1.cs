    // Item base class
    public Dictionary<string, object> Attributes { get; private set; }
    
    public List<Process> Enchantments { get; private set; }
    
    public virtual T Get<T>(string identifier)
    {
    	var att = this.Attributes.FirstOrDefault(att => att.Key == identifier);
    	if (att == null) throw new MissingAttributeExeption(identifier); // Or perhaps just return default(T)
    	if ((att.Value is T) == false) throw new InvalidAttributeCastException(identifier, typeof(T));	
    
    	var value = att.Value;
    	foreach (var ench in this.Enchantments)
    	{
    		ench.Modify(identifier, ref value);
    	}
    	
    	return value as T; // Maybe you need to cast value to Object, and then to T, I can't remember.
    }
    
    // Process class
    
    public string ValueToModify { get; set }
    
    public virtual void Modify(string identifier, ref object value)
    {
    	if (identifier != this.ValueToModify) return;
    	
    	// In an inherited class, for example a Weightless-Enchantment: Halfs all weight
    	var castedVal = value as int
    	value = castedVal / 2;
    	// Now this one item weights 50% of normal weight, and the original value is still stored in Item's Attributes dictionary.
    }
    
    // Some random class
    
    public void Update()
    {
    	var totalWeight = 0;
    	foreach (var item in this.itemCollection)
    	{
    		int weight = item.Get<int>("Weight");
    		totalWeight += weight;
    	}
    	Console.WriteLine("The player weights: {0}", totalWeight);
    }
