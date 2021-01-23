    public class XElementComparer : IEqualityComparer<XElement>
    {
      
        public bool Equals(XElement x, XElement y)
        {
            return x.Parent.Attribute("Id").Value == y.Parent.Attribute("Id").Value;
        }
    
        public int GetHashCode(XElement obj)
        {
            string val = obj.Parent.Attribute("Id").Value;
            return val.GetHashCode();
        }
    }
