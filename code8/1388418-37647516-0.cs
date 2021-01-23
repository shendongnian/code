    [Flags]
    public enum Props
    {
    	FirstName = 1,
    	Surname = 2,
    	Address = 4,
    	Occupation = 8
    }
    
    public string GetValues(int id, Props props)
    {
    	var items = new Dictionary<string, string>();
    
    	if (props == 0 || props.HasFlag(Props.FirstName))
    		items.Add("FirstName", "Bob");
    
    	if (props == 0 || props.HasFlag(Props.Surname))
    		items.Add("Surname", "Smith");
    
    	if (props == 0 || props.HasFlag(Props.Address))
    		items.Add("Address", "London");
    
    	if (props == 0 || props.HasFlag(Props.Occupation))
    		items.Add("Occupation ", "Professional Tea Drinker");
    
        //Using Newtonsoft Json:
    	return JsonConvert.SerializeObject(items);
    }
