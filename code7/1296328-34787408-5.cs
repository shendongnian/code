        [ModelBinder(typeof(OrderBinder))]
        public class OrderDTO
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public Decimal Amount { get; set; }
        }
