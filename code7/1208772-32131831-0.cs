    public sealed class MyTuple : IEquatable<MyTuple>
    {
        private readonly string _Id; 
        private readonly double _Value1; 
        private readonly double _Value2;
    
        public string Id { get { return _Id; } } 
        public double Value1 { get { return _Value1; } } 
        public double Value2 { get { return _Value2; } }
    
        public MyTuple(string Id, double Value1, double Value2)
        {
            _Id = Id; 
            _Value1 = Value1; 
            _Value2 = Value2;    
        }
    
        public override bool Equals(object obj)
        {
            if (obj is MyTuple)
                    return Equals((MyTuple)obj);
            return false;
        }
        
        public bool Equals(MyTuple obj)
        {
            if (obj == null) return false;
            if (!EqualityComparer<string>.Default.Equals(_Id, obj._Id)) return false; 
            if (!EqualityComparer<double>.Default.Equals(_Value1, obj._Value1)) return false; 
            if (!EqualityComparer<double>.Default.Equals(_Value2, obj._Value2)) return false;    
            return true;
        }
        
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= EqualityComparer<string>.Default.GetHashCode(_Id); 
            hash ^= EqualityComparer<double>.Default.GetHashCode(_Value1); 
            hash ^= EqualityComparer<double>.Default.GetHashCode(_Value2);
            return hash;
        }
        
        public override string ToString()
        {
            return String.Format("{{ Id = {0}, Value1 = {1}, Value2 = {2} }}", _Id, _Value1, _Value2);
        }
    }
