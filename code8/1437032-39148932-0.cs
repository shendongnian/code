    public class Products : IXmlSerializable, IEnumerable<ProductExport>
    {
        private readonly List<ProductExport> _products = new List<ProductExport>();
    
        public void Add(ProductExport product) => _products.Add(product);
    
        public XmlSchema GetSchema() => null;    
    
        public void ReadXml(XmlReader reader)
        {
            throw new NotSupportedException();
        }
    
        public void WriteXml(XmlWriter writer)
        {
            foreach (var product in this)
            {
                writer.WriteStartElement("R" + product.Code);
                product.WriteXml(writer);
                writer.WriteEndElement();
            }        
        }
    
        public IEnumerator<ProductExport> GetEnumerator() => _products.GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
