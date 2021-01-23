        [NotMapped]
        public class ProductVM 
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int IssuedQuantity { get; set; }
            public int InhandQuantity { get; set; }
            public virtual ICollection<OrderedItem> OrderedItems { get; set; }
            ...
        }
