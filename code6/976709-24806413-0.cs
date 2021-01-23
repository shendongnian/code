    public class TestClass
    {
        [XmlAttribute(@"Points")]
        public string PointsString
        {
            get { return Points.ToString(); }
            set { throw new NotSupportedException(); }
        }
        [XmlIgnore]
        public PointXY Points { get; set; }
    }
