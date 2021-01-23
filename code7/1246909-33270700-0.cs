      [Serializable]
        public class MaybankeBPGResponse
       { 
        public DateTime? AuthDate { get; set; }
    
        [XmlElement("TRAN_DATE")]
         public string AuthDateXML { get; set; }
    
       }
