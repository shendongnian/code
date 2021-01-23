    var contacts = new List<Contact>
    {
    	new Contact { FirstName = "Tom", LastName = "Jones", Phone = "555-555-555" },
    	new Contact { FirstName = "Sophie", LastName = "Monk", Phone = "333-333-333" },
    	new Contact { FirstName = "Mark", LastName = "Twain", Phone = "111-111-111" }
    };
    
    var callLogs = new List<CallLog>
    {
    	new CallLog { Number = "555-555-555", Incoming = true },
    	new CallLog { Number = "555-555-555", Incoming = true },
    	new CallLog { Number = "333-333-333", Incoming = true },
    	new CallLog { Number = "333-333-333", Incoming = true },
    	new CallLog { Number = "333-333-333", Incoming = true }
    };
    
    var data = contacts.Select(c => new 
    	{
    		who = string.Format("{0} {1} {2}", c.FirstName, c.LastName, c.Phone),
    		how_many = callLogs.Count(l => l.Number == c.Phone && l.Incoming)
    	}).ToList();
    
    data.Dump();
    
    }
    
    public class Contact
    {
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    	public string Email { get; set; }
    	public string Phone { get; set; }
    	public DateTime DateOfBirth { get; set; }
    	public string State { get; set; }
    }
    
    public class CallLog
    {
    	public string Number { get; set; }
    	public int Duration { get; set; }
    	public bool Incoming { get; set; }
    	public DateTime When { get; set; }
