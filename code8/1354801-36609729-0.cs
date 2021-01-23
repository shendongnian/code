    [Serializable]
    [XmlRoot("ProdutosServicos")]
    public class ProdutosServicos
    {
        [XmlElement("Producto")]
        public List<Produto> Produto { get; set; }
    }
    
    [Serializable]
    public class Produto
    {
        public string Descricao { get; set; }
        public CodigoTipo Codigo { get; set; }
        public string Quantidade { get; set; }
        public string Unidade { get; set; }
        public string ValorUnitario { get; set; }
    }
    [Serializable]
    public class CodigoTipo
    {
    
    }
