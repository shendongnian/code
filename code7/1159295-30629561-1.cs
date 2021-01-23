    public Invoice()
    {
    	//....
    	public Section AddSection()
    	{
            var s = new Section(this);
    		Sections.Add(s);
            return s;
    	}
    	//...
    }
