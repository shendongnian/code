    void Main()
    {
        var txt = "that i have not had not that place"
        	.Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
    	    .ToList();
    
        var dict = new OrderedDictionary();
        var output = new List<int>();
    
        foreach (var element in txt.Select ((word,index) => new{word,index}))
        {
        	if (dict.Contains(element.word))
    	    {
        		var count = (int)dict[element.word];
        		dict[element.word] = ++count;
    		    output.Add(GetIndex(dict,element.word));
    	    }
        	else
        	{
    		    dict[element.word] = 1;
    	    	output.Add(GetIndex(dict,element.word));
        	}
        }
    }
    public int GetIndex(OrderedDictionary dictionary, string key) 
    {
        for (int index = 0; index < dictionary.Count; index++)
        {
            if (dictionary[index] == dictionary[key]) 
                return index; // We found the item
        }
    
        return -1;
    }
