    public class SendRequest
    {
        public List<int> channelsIds {get;set;}
        public List<uint> destinationsIds {get;set;}
        public string content {get;set;} 
        public string title {get;set;}
        public MessagePriority priority {get;set;}
    }
