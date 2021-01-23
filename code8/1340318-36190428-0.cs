    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    [XmlInclude(typeof(finalizacaoOrcamentoVO))]
    public partial class IFX
    {
        private IFXDadosOrcamento dadosOrcamentoField;
        public IFXDadosOrcamento dadosOrcamento { get { return dadosOrcamentoField; } set { dadosOrcamentoField = value; } }
    }
    public class finalizacaoOrcamentoVO : IFX
    {
        // This derived type may have some or all of the properties shown as elements in the XML file.
    }
    public class IFXDadosOrcamento
    {
        public string IFXDadosOrcamentoValue { get; set; }
    }
