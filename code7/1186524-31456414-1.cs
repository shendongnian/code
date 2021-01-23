    public class Record
    {
    	public string Name { get; set; }
    	
    	public string Contact { get; set; }
    	
    	//...
    	public Record(string name, string contact)
    	{
    		this.Name = name;
    		this.Contact = contact;
    	}
    	
    	public Record(Record r)
    	{
    		this.Name = r.Name.ReplaceQuotes();
    		this.Contact = r.Contact.ReplaceQuotes();
    	}
    }
