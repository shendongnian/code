    public class NotificationComparer : IEqualityComparer<Notification>
    {
        public bool Equals(Notification x, Notification y)
        {
            return x.ID == y.ID;
        }
    
        public int GetHashCode(Notification obj)
        {
            return obj.ID == null ? 0 : obj.ID.GetHashCode();
        }
    }
