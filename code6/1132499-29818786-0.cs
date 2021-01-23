    class SearchCriteria
    {
       public string Name { get; set; }
       public string Email { get; set; }
       public string Company { get; set; }
    
    
       public void Trim()
       {
    		if(!String.IsNullOrEmpty(Name)) Name = Name.Trim();
    		if(!String.IsNullOrEmpty(Email)) Email = Email.Trim();
    		if(!String.IsNullOrEmpty(Company)) Company = Company.Trim();
       }
    }
    void Main()
    {
    	var criteria = new SearchCriteria();
    	criteria.Email = "thing ";
    	Console.WriteLine(criteria.Email.Length);
    	criteria.Trim();
    	Console.WriteLine(criteria.Email);
    	Console.WriteLine(criteria.Email.Length);
    }
