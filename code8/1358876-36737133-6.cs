    public SelectedItemMessage(object sender, double age, int category) : base(sender)
    	{
    		Age = age;
    		Category = category;
    	}
    	
    	public double Age { get; set; }
    	public int Category{ get; set; }
    }
