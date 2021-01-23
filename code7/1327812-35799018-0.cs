    [MetadataType(typeof(AnimalMetaData))]
    public partial class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfLegs { get; set; } etc..
    public class AnimalMetaData
    {
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
    
        [MaxLength(1000)]
        public string Description { get; set; } etc...
