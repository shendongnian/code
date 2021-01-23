    public class Car : IAudit
    {
        //snip
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
    }
