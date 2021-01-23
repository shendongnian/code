    private class AuditCache
    {
        public Guid ObjectId;
        public int HistoryId;
        public DateTime? DateFrom;
        public DateTime? DateTo;
        public string Value;
    
        public override bool Equals(Object obj)
        {
           if (obj == null || ! (obj is AuditCache)) 
              return false;
           else 
              return this.ObjectId == ((AuditCache) obj).ObjectId;
        }      
    
        public override int GetHashCode()
        {
           return GetHashCode(ObjectId );
        }
    };
