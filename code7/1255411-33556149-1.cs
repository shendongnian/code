    public class PriceOfDish
    {
        [Key]
        public int Dish_ID { get; set; }
        [Key]
        public DateTime DateTime { get; set; }
        [ForeignKey("Dish_Id")]
        public virtual Dish Dish { get; set; }
        public decimal Price { get; set; }
   }
