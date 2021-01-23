    public sealed class Sent : IEquatable<Sent>
    {
        private readonly string _Address; 
        private readonly string _Data;
    
        public string Address { get { return _Address; } } 
        public string Data { get { return _Data; } }
    
        public Sent(string Address, string Data)
        {
            _Address = Address; 
            _Data = Data;    
        }
    
        public override bool Equals(object obj)
        {
            if (obj is Sent)
                    return Equals((Sent)obj);
            return false;
        }
        
        public bool Equals(Sent obj)
        {
            if (obj == null) return false;
            if (!EqualityComparer<string>.Default.Equals(_Address, obj._Address)) return false; 
            if (!EqualityComparer<string>.Default.Equals(_Data, obj._Data)) return false;    
            return true;
        }
        
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= EqualityComparer<string>.Default.GetHashCode(_Address); 
            hash ^= EqualityComparer<string>.Default.GetHashCode(_Data);
            return hash;
        }
    }
