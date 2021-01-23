    [Table("PoolCar")]
    public class PoolCar
    {
        [Key, ForeignKey("company")]
        public int poolCarId { get; set; }
        public int companyId { get; set; }
        public Company company { get; set; }
        public string poolCarName { get; set; }
        // navigation property
        public virtual IList<CarAllocation> carAllocations { get; set; }
    }   
