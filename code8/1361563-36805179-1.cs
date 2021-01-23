    public abstract class Person
    {
    	public abstract string FirstName {get; protected set; }
    	public abstract string MiddleName { get; protected set; }
    	public abstract string LastName { get; protected set; }
    	
    	public Person(string firstName, string middleName, string lastName){
    		FirstName = firstName;
    		MiddleName = middleName;
    		LastName = lastName;
    	}
    }
    
    public class PersonNeedAllProperties : Person
    {
    	public override string FirstName{get; protected set;}
    	public override string MiddleName{get; protected set;}
    	public override string LastName{get; protected set;}
    	
    	public PersonNeedAllProperties(
    		string firstName,
    		string lastName,
    		string middleName)
    		: base(firstName, lastName, middleName)
    	{
    	}
    }
