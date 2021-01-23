    public class ProdutosServicos
    {
        // This is the attribute that makes your XML Array looks like a list of XML Elements.
        [XmlElement]
        public List<Produto> Produto { get; set; }
    }
