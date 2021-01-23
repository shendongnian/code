     public class OrderItemViewModel
     {
        public int orderItemId { get; set; }
        [DataType(DataType.MultilineText)]
        public string orderItemDescr { get; set; }
        public string orderItemText { get; set; }
        public double orderItemFixeedPrice { get; set; }
        public virtual Order orderItemOrder { get; set; }
        public virtual OrderItemType orderItemType { get; set; }
        public virtual ICollection<Time> orderItemTime { get; set; }
        public virtual ICollection<Material> orderItemMaterial { get; set; }
        public string orderItemTypeDescr
        {
            get
            {
                return this.orderItemType.orderItemTypeNumber.ToString() + " - " + this.orderItemDescr;
            }
        }
     }
