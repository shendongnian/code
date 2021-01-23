    class Program
    {
       static void Main(string[] args)
       {
           var t = Global.Channels;
       }
    }
    [Serializable]
    public class Blah
    {
       [OnDeserialized]
       public void DoSomething(StreamingContext context)
       {
           Global.Channels.DoIt();
       }
    }
    
    public interface IChannelsData { void DoIt(); }
    class ChannelsData : IChannelsData
    {
    	public static Blah _b = Deserialize();
    	public static Blah Deserialize()
    	{
    		var b = new Blah();
    		b.DoSomething(default(StreamingContext));
    		return b;
    	}
    	public void DoIt() 
    	{
    		Console.WriteLine("Done it");
    	}
    }
    
    static class Global
    {
        public static readonly IChannelsData Channels = new ChannelsData();
        public static readonly IMessagesData Messages = new MessagesData();  
    }
