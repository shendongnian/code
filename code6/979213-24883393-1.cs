    public class ZoneModel
    {
        public int ZoneID { get; set; }
        public int FK_ProductID { get; set; }
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public virtual List<DisplayDuration> DisplayDurations { get; set; }
    }
