    public class Student
    {
    	private string _firstName;
    	private string _lastName;
    	public Student(string firstName, string lastName)
    	{
    		_firstName = firstName;
    		_lastName = lastName;
    	}
    
    	public string FullName
    	{
    		get
    		{
    			return _firstName + " " + _lastName;
    		}
    	}
    }
