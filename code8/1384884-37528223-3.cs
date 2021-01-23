     public class CommunicationMessage : Dictionary<string, object>       
     {
        //this "hack" exposes the "Child" as a List
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
