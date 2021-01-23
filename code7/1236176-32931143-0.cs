    public List<MyObject> Search(string colour, string size, string name)
    {
        IEnumerable<MyObject> result = MyTable;
    	
    	if(colour != null)
    		result = result.Where(o => o.Colour == colour);
    
    	if(size != null)
    		result = result.Where(o => o.Size == size);
    
    	...
    
    	return result.ToList();
    }
