    void Main()
    {
    	List<Customer> customers = new List<Customer> {
    	   new Customer { 
    	   		CustomerId=1,
    			Events = new List<Event> {
    				new Event {EventId=1, CustomerId=1, EventDate=new DateTime(2016,2,19)},
    				new Event {EventId=2, CustomerId=1, EventDate=new DateTime(2016,2,19)},
    			}
    		},
    		new Customer { 
    			CustomerId = 2,
    			Events = new List<Event> {
    				new Event {EventId=6, CustomerId=2, EventDate=new DateTime(2016,4,25)},
    				new Event {EventId=7, CustomerId=2, EventDate=new DateTime(2016,4,25)},
    			   	new Event {EventId=3, CustomerId=2, EventDate=new DateTime(2016,4,22)},
    				new Event {EventId=4, CustomerId=2, EventDate=new DateTime(2016,4,22)},
    				new Event {EventId=5, CustomerId=2, EventDate=new DateTime(2016,4,22)},
    				new Event {EventId=8, CustomerId=2, EventDate=new DateTime(2016,4,26)},
    				new Event {EventId=8, CustomerId=2, EventDate=new DateTime(2016,4,26)},
    			}
    		},
    	};
    
    	var counts = from c in customers
    				 select new {
    					 c.CustomerId,
    					 Counts = c.Events
    					 	.GroupBy(e => e.EventDate)
    						.Select(e => new {Date= e.Key,Count= e.Count()})
    						.OrderBy(e => e.Date)
    				 };
    }
    
    public class Customer
    {
    	public int CustomerId { get; set; }
    	public virtual List<Event> Events {get;set;}
    }
    
    public class Event
    {
    	public int EventId {get;set;}
    	public DateTime EventDate { get; set; }
    	public int CustomerId { get; set; }
    }
