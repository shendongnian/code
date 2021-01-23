    namespace Facturacion.Models
    {
        public class Test
        {
            public int testId { get; set; }    
            [Required]
            public decimal price { get; set; }
            public decimal calculated
            {
                get
                {
                    return (decimal)(price*2);
                }
            }
        }
    }
