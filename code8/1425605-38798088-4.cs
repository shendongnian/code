    public class Person
    {
        ...
        [ForeignKey("BestFoodId")]
        [InverseProperty("Persons")]
        public Food BestFood { get; set; }
        ...
    }
