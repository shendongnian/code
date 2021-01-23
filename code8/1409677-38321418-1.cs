    public class MyComparer : IEqualityComparer<XElement>
    {
        private XName _element_id;
        public MyComparer(XName element_id)
        {
            _element_id = element_id;
        }
        public bool Equals(XElement x, XElement y)
        {
            return x.Element(_element_id).Value.Equals(y.Element(_element_id).Value);
        }
        public int GetHashCode(XElement el)
        {
            return el.Element(_element_id).Value.GetHashCode();
        }
    }
