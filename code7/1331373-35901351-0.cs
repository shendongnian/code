    public static void Main()
    {
    	Contact oldContact = new Contact{
    		name = "John", 
    		email = "John@example.com", 
    		age = 40
    	};
    	Contact newContact = new Contact{
    		name = "Joshua",
    		email = "John@example.com",
    		age = 42
    	};
    	Type contactType = oldContact.GetType();
    	foreach (PropertyInfo property in contactType.GetProperties())
    	{
    		property.SetValue(oldContact, property.GetValue(newContact));
    	}
    	Console.WriteLine(oldContact.age);
    }
    
    public class Contact
    {
    	public String name { get; set; }
    	public String email { get; set; }
    	public int age { get; set; }
    }
