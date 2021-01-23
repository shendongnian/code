    class Customer
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public string FullName { get { return FirstName + " " + LastName; } }
    }
