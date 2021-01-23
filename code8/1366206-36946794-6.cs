    public class DynamicXmlExt : DynamicObject
    {
        XElement _root;
        private DynamicXmlExt(XElement root)
        {
            _root = root;
        }
        public static DynamicXmlExt Parse(string xmlString)
        {
            return new DynamicXmlExt(XDocument.Parse(xmlString).Root);
        }
        public static DynamicXmlExt Load(string filename)
        {
            return new DynamicXmlExt(XDocument.Load(filename).Root);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            var att = _root.Attribute(binder.Name);
            if (att != null)
            {
                result = att;
                return true;
            }
            var nodes = _root.Elements(binder.Name);
            if (nodes.Count() > 1)
            {
                result = nodes.Select(n => new DynamicXmlExt(n)).ToList();
                return true;
            }
            var node = _root.Element(binder.Name);
            if (node != null)
            {
                if (node.HasElements)
                {
                    result = new DynamicXmlExt(node);
                }
                else
                {
                    result = node;
                }
                return true;
            }
            return true;
        }
    }
