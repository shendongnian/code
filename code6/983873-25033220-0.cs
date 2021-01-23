    public class Message
    {
        public string type { get; set; }
        public string action { get; set; }
    }
    public class CancelMessage : Message
    {
        public string ref { get; set; }
        public string message { get; set; }
        
        public static implicit operator CancelMessage(JObject message)
        {
            var output = JsonConvert.DeserializeObject<CancelMessage>(message.ToString());            
            return output;
        }
    }
    
    public void ProcessMessage(dynamic message)
    {
        switch ((string)message.action)
        {
            case "CANCEL":
                ProcessCancelMessage(message);
                break;
        }
    }
    private void ProcessCancelMessage(CancelMessage message)
    {
          //Cancel
    }
    
