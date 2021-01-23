    [Serializable]
    public class SimpleSensor
    {
        [XmlElement("ID")]
        public string Id { get; set; }
    
        [XmlArray("Function")]
        public double[] Coefficient { get; set; }
    
        //## Constructor:
        public SimpleSensor()
        {
            Id = "00";
            double[] content = new double[2] { 0, 1 };
            Coefficient = content;           
        }
    }
