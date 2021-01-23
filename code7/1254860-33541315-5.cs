    public class Address
    {
    	public int Id {get; set;}
    	
    	public int HouseId {get; set;}
    	
    	public string AddressLine1 { get; set;}
    	
    	public House House {get; set;}
    }
    public class House
    {
    	public int Id {get; set;}
    	public string HouseType {get; set;}
    	
    	public virtual ICollection<Occupant> Occupants { get; set;}
    }
    
    public class Occupant
    {
    	public int Id {get; set;}
    	
    	public int HouseId {get; set;}
    	public int PersonId {get; set;}
    	
    	public bool IsOwner {get; set;}
    	public DateTime StartDate {get; set;}
    	public DateTime EndDate {get; set;}
    	
    	public Person Person {get; set;}
    	public House House {get; set;}
    }
    
    public class Person 
    {
    	public int Id {get; set;}
    	public string FirstName {get; set;}
    }
    
