    public class Wrapper
    {
    	public Student Student { get; set; }
    }
    
    public class Student
    {
    	[JsonProperty("fname")]
    	public string FirstName { get; set; }
    	[JsonProperty("lname")]
    	public string LastName { get; set; }
    	[JsonProperty("subject")]
    	public string Subject { get; set; }
    	[JsonProperty("grade")]
    	public string Grade { get; set; }
    }
