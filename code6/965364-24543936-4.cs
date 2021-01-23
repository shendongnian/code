    public class Expenditure : Relationship
    {
        /// <summary>
        /// Inherits from Content: Id, Handle, Description, Parent (is context of expenditure and usually 
        /// a Project)
        /// Inherits from Relationship: Source (the Principal), SourceId, Target (the Supplier), TargetId, 
        /// 
        /// </summary>
        [Required, InverseProperty("Expenditures"), ForeignKey("ProductId")]
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public string Unit { get; set; }
        public double Qty { get; set; }
        public string Currency { get; set; }
        public double TotalCost { get; set; }        
        
    }
