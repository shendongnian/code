    public abstract class Animal {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int NumberOfLegs { get; set; }
    }
