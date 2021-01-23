     public class ProductsTable
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public ICollection<RxTable> RxTable { get; set; }
    }
    public partial class DrugsTable
    {
        public int DrugID { get; set; }
        public string Strength { get; set; }
        public string GCNSeqNo { get; set; }
        public virtual ICollection<RxTable> RxTable { get; set; }
    }
    public class Person
    {
        public int PersonID { get; set; }
        public virtual ICollection<RxTable> RxTable { get; set; }
    }
    public class RxTable
    {
        [Key, Column(Order = 0)]
        public int ProductID { get; set; }
        [Key, Column(Order = 1)]
        public int DrugID { get; set; }
        [Key, Column(Order = 2)]
        public int PersonID { get; set; }
        public virtual ProductsTable ProductsTable { get; set; }
        public virtual DrugsTable DrugsTable { get; set; }
        public virtual Person Person { get; set; }
    }
