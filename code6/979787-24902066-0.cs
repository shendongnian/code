    class MsgComparer : IEqualityComparer<MessageDTO>
    {
        public bool Equals(MessageDTO x, MessageDT Oy)
        {
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(MessageDTO m)
        {
        }
    
    }
