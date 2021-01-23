    namespace Your_NameSpace
        {
        [Table("Products")]
        public class Products
            {
               [DatabaseGenerated(DatabaseGeneratedOption.Identity)] \\ If you have identity set in table Products, if not remove this line
               [Key] // Primary key
               public int ProductID { get; set; }
               public string ProductName { get; set; }
               public string ProductPrice { get; set; }
            }
         }
