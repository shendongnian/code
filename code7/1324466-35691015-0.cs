    void Main()
    {
    	var messages = GenerateTestData();	
    	var results = messages.OrderBy(o => o.Type)
                   .ThenBy(p => p.IsUrgent)
                   .ThenByDescending(p => p.TimeStamp)
                   .ToList();		   
    	foreach (var m in results)
    	{
    		Console.WriteLine(m.ToString());
    	}
    }
    
    public List<Message> GenerateTestData()
    {
    	var result = new List<Message>(10){
    	
    	new Message(){ Type = MessageType.New, IsUrgent = true, TimeStamp = DateTime.Now.AddMilliseconds(10).Ticks},
    	new Message(){ Type = MessageType.Saved, IsUrgent = true, TimeStamp = DateTime.Now.AddMilliseconds(9).Ticks},
    	new Message(){ Type = MessageType.Deleted, IsUrgent = false, TimeStamp = DateTime.Now.AddMilliseconds(8).Ticks},
    	new Message(){ Type = MessageType.Deleted, IsUrgent = false, TimeStamp = DateTime.Now.AddMilliseconds(7).Ticks},
    	new Message(){ Type = MessageType.Saved, IsUrgent = false, TimeStamp = DateTime.Now.AddMilliseconds(6).Ticks},
    	new Message(){ Type = MessageType.New, IsUrgent = true, TimeStamp = DateTime.Now.AddMilliseconds(5).Ticks},
    	new Message(){ Type = MessageType.Saved, IsUrgent = true, TimeStamp = DateTime.Now.AddMilliseconds(4).Ticks},
    	new Message(){ Type = MessageType.Saved, IsUrgent = false, TimeStamp = DateTime.Now.AddMilliseconds(3).Ticks},
    	new Message(){ Type = MessageType.Deleted, IsUrgent = true, TimeStamp = DateTime.Now.AddMilliseconds(2).Ticks},
    	new Message(){ Type = MessageType.New, IsUrgent = false, TimeStamp = DateTime.Now.AddMilliseconds(1).Ticks}
    	};
    	return result;
    }
    
    public enum MessageType
    {
    	New,
    	Saved,
    	Deleted
    }
    public class Message
    {
    	public MessageType Type{get;set;}
    	public bool IsUrgent{get;set;}
    	public long TimeStamp {get;set;}
    	
    	public  override string ToString()
    	{
    		return string.Format("Type: {0}, IsUrgent: {1}, TimeStamp: {2}",this.Type, this.IsUrgent, this.TimeStamp);
    	}
    }
