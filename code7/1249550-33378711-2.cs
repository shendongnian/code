    public class FruitType
    {
        [Key]
        public int FruitTypeID {get;set;}
        public string FruitName {get;set;}
    }
    public class Fruit
    {
        [Key]
        public int FruitID { get; set; }
        public int FruitTypeID { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public FruitTypeEnum TheFruitTypeEnum { get{ return (FruitTypeEnum)FruitTypeID; } }
        [ForeignKey("FruitTypeID")]
        public virtual FruitType TheFruitTypeEntity {get; set;}
    }
