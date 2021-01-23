    using System;
    
    class Person
        {
       
       	public String FirstName {get; set;}
    	public String LastName {get; set;}
    	public String SocialNb {get; set;}
    	
        public ContactInfo Contact {get; set;}
    	public AddressInfo Address {get; set;}
    
        public Person(string firstname, string lastname, string socialnb, string, email, string phone, string streetaddress, string postcode, string city)
        {
    		Contact = new ContactInfo(email,phone);
    		Address = new AddressInfo(streetaddress,postcode,city);
    		FirstName = firstname;
    		LastName = lastname;
    		SocialNb = socialnb;
        }
    
        public String ToString() // Incomplete
        {
        return "\n\t"; // Will include all fields in the class
        }
    	
    class ContactInfo
    {
    	public String Email {get; set;}
    	public String Phone {get; set;}
    	
    	public ContactInfo(String email = "", String phone = "") 
    	{ 
    		Email = email;
    		Phone = phone;
    	}
    }
    
    class AddressInfo
    {
    	public String Street {get; set;}
    	public String Postcode {get; set;}
    	public String City {get; set;}
    	
    	public AddressInfo(String street = "", String postcode = "", String city = "") 
    	{ 
    		Street = street;
    		Postcode = postcode;
    		City = city;
    	}
    }
