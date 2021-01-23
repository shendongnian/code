    public class Notification
    {
        public enum Type {
    
            Promotion,
           Other
        }
        public string ID { get; set; }
        public string Headline { get; set; }
        public string Detail { get; set; }
        public Type NotificationType { get; set; }
    
        public override bool Equals(object obj)
        {
            return obj is Notification && string.Equals(ID, ((Notification)obj).ID);
        }
    
        public override int GetHashCode()
        {
            return ID == null ? 0 : ID.GetHashCode();
        }
    }
