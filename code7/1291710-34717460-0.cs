    public class Consumable 
    {
        public int ConsumableId { get; set; }
        public string Description { get; set; }
        public int SaleDepartmentId { get; set; }
        [ForeignKey("SaleDepartmentId")]
        public virtual SaleDepartment SaleDepartment { get; set; }
    }
