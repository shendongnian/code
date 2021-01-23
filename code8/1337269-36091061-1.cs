    public class Student
    {
    
    	public int ID { get; set; }
    	public string Name { get; set; }
    
    	public int StandardRefId { get; set; }
    
    	[ForeignKey("StandardRefId")]
    	public Standard Standard { get; set; }
    }
    
    public class Standard
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    
    	public ICollection<Student> Students { get; set; }
    }
