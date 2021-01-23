    public class DistributionViewModel
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string Description { get; set; }
        public Byte EyeDee { get; set; }
        public string DestinationPath { get; set; }
        public List<JRI.DMP.BLL.Filter> Filters { get; set; }
    }
