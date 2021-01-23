    namespace public_transportaion.Models //or ORM
    {
        [Table("delays_table", Schema = "YourSchemaHere")]
        public class delays_table
        {
            [Key]
            public string agency_name { get; set; },
            public int COUNT { get; set; }
        }
    }
