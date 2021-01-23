    public class PriceOfDish
    {
        [Key]
        public int Dish_ID { get; set; }
        [Key]
        public DateTime DateTime { get; set; }
        public virtual List<Dish> Dishes { get; set; }
        public decimal Price { get; set; }
   }
