    public void Add(Dictionary<string, int> arr_dict, string key)
    {
    	arr_dict[key] = arr_dict[key] + 1;
    }
    
    public void Update(Dictionary<string, int> arr_dict, string key, int value)
    {
    	arr_dict[key] = value;
    }
