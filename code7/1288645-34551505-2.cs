    [System.ComponentModel.DataAnotations.Table("Products")]
    public class Product
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
    }
