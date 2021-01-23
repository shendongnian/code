     public class CommunicationMessage : Dictionary<string, object>       
     {
        public List<CommunicationMessage> Childs
        {
            get {
                return (List<CommunicationMessage>)this["Childs"];
            }
            set
            {
                this["Childs"] = value;
            }
        }
        public CommunicationMessage()
        {
            this["Childs"] = new List<CommunicationMessage>();
        }
     }
