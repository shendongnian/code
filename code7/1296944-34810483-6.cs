    public class PersonViewModel
    {
    	//your person fields here..
    	//create them with the same name as Person 
    	//to avoid having to set each field during mapping	
    }
    
    public class AddressViewModel
    {
    	//your address fields here..
    }
    
    public class AdminViewModel
    {
    	public PersonViewModel Person {get; set;}	
    	
    	public AddressViewModel Address {get; set;}	
    }
