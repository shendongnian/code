    public class EmployeeCar {
        [Key, Column(Order = 0)]
        public int CarId { get; set; }
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }
        public virtual Car Car { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime DateFrom{ get; set; }
        public DateTime DateTo { get; set; }
    }  
