    public void Add(Dictionary<string, int> arr_dict, int index, string key)
    {
    	arr_dict[index][key] = arr_dict[index][key] + 1;
    }
    
    public void Update(Dictionary<string, int> arr_dict, int index, string key, int value)
    {
    	arr_dict[index][key] = value;
    }
