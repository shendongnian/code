    public class TestClass
    {
        [XmlIgnore]
        public PointXY Points { get; set; }
        
        [XmlAttribute("Points")]
        public string PointString
        {
            get
            {
                return string.Format("{0} {1}",Points.X, Points.Y);
            }
            set
            {
                // TODO:  Add null checking, validation, etc.
                string[] parts = value.Split(' ');
                Points = new PointXY {X = double.Parse(parts[0]), Y = double.Parse(parts[1])};
            }
        }
    }
