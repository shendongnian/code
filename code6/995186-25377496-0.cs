    namespace My.GIS.Viewer.Configuration.Map
    {
        [Serializable()]
        public class FeatureLayerExtension
        {
            
            public string WhereString{ get; set; }
        
            public string OutFields { get; set; }
        
            public string UniqueDataCount { get; set; }
            
            //SimpleFillSymbol should be a list   
            [XmlElement("SimpleFillSymbol")]
            public List<SimpleFillSymbol> SimpleFillSymbolList = new List<SimpleFillSymbol>();
    
        }
        
        [Serializable()]
        public class SimpleFillSymbol
        {
            [XmlAttribute("Color")]
            public string Color { get; set; }
        
            [XmlAttribute("Fill")]
            public string Fill { get; set; }
        
            [XmlAttribute("Width")]
            public string Width { get; set; }
        
            [XmlAttribute("Fvalue")]
            public string Fvalue { get; set; }
        
        }
    }
