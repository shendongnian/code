    public class Character
    {
    	public string FirstName { get; private set; }
    	public string LastName { get; private set; }
    
    	public Character(string firstName, string lastName)
    	{
    		FirstName = firstName;
    		LastName = lastName;
    	}
    }
