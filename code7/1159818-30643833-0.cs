    class CustomerHairCutPreference {
       public int ID { get; set; }
       public Customer Customer { get; set; }
       public int HairCutStyleID {get; set; }
       [NotMapped]
       public HairCutStyle HairCutStyle { get; set; }
    }
