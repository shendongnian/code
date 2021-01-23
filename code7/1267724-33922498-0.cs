    public class Name
    {
    	public string familyName { get; set; }
    	public string givenName { get; set; }
    }
    
    public class UserProperties
    {
    	public Name name { get; set; }
    	public string email { get; set; }
    	public string mobile { get; set; }
    	public string role { get; set; }
    	public string specialty { get; set; }
    	public string department { get; set; }
    }
    
    public class RootObject
    {
    	public string cuid { get; set; }
    	public string invitationStatus { get; set; }
    	public bool isEnabled { get; set; }
    	public UserProperties userProperties { get; set; }
    }
