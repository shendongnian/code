    private List<Person> visiblePersons;
    public List<Person> VisiblePersons
    {
    	get { return visiblePersons; }
    	set
    	{
    		visiblePersons = value;
    		OnPropertyChanged();
    	}
    }
