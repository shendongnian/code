    public class DictionaryEqualityComparer : IEqualityComparer<Dictionary<string,object>>
    {
        public bool Equals(Dictionary<string, object> x, Dictionary<string, object> y)
        {
            object xid,yid;
            return x.TryGetValue("ID", out xid) 
                && y.TryGetValue("ID", out yid)
                && ((int)xid == (int)yid); //note: `int` only for example, use your type for "ID" key
        }
        public int GetHashCode(Dictionary<string, object> obj)
        {
            object xid;
            return obj.TryGetValue("ID", out xid) ? xid.GetHashCode() : obj.GetHashCode();
        }
    }
