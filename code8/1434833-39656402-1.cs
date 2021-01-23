        [Serializable]
        [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
        [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
        public class G_TFS {
        [XmlElement(Order=0)]
        public S_TFS S_TFS {get; set;}
        [XmlElement("S_REF_2",Order=1)]
        public List<S_REF_2> S_REF_2 {get; set;}
        [XmlElement("S_DTM_2",Order=2)]
        public List<S_DTM_2> S_DTM_2 {get; set;}
        [XmlElement("S_MSG",Order=3)]
        public List<S_MSG> S_MSG {get; set;}
        [XmlElement("G_N1_2",Order=4)]
        public List<G_N1_2> G_N1_2 {get; set;}        
        [XmlElement("G_FGS",Order=5)]
        public List<G_FGS> G_FGS {get; set;}
        [XmlElement("G_TIA",Order=6)]
        public List<G_TIA> G_TIA {get; set;}
        }
