        public class IdDataClass : IEquatable<IdDataClass>
    {
        int _ID;
        string _MyData;
        public IdDataClass(int ID, string Data)
        {
            _ID = ID;
            _MyData = Data;
        }
        public bool Equals(IdDataClass p)
        {
            return (_ID == p._ID) && (_MyData == p._MyData);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IdDataClass))
                return false;
            else
                return Equals(obj as IdDataClass);
        }
        public override int GetHashCode()
        {
            return _ID.GetHashCode() ^ _MyData.GetHashCode();
        }
    }
