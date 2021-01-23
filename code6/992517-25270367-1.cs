    public class Package
    {
        public string Name { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int Weight { get; set; }
        public bool IsFragile { get; set; }
        public string Description { get; set; }
        public PackageType Type { get; set; }
    
        public int? Volume
        {
            get
            {
                if (Height != null && Width != null && Length != null)
                {
                    return (int) Height*(int) Width*(int) Length;
                }
                return null;
            }
        }
    
    }
