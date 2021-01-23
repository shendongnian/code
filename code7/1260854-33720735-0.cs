    public partial class CityIp
    {
        [Key]
        public byte[] IpStart { get; set; }
        public byte[] IpEnd { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
    }
