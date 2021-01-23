    [Table("CustomerInventorys")]
    public class CustomerInventory
    {
        public long ID { get; set; }
        public long CustomerID { get; set; }
        public virtual ICollection<CycleCount> CycleCounts { get; set; }
    }
    [Table("CycleCounts")]
    public class CycleCount
    {
        public long ID { get; set; }
        public long CustomerInventoryItemID { get; set; }
        public virtual CustomerInventory CustomerInventoryItem  { get; set; }
    }
