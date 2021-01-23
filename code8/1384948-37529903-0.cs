    using System.ComponentModel.DataAnnotations;
    public class MyEntity
    {
        public MyEntity()
        { 
        }
    
        [Key]
        public int Id { get; set; }
        public decimal initialQuantity { get; set; }
            
        [NotMapped]
        public decimal finalQuantity => initialQuantity*1.05m;
    }
