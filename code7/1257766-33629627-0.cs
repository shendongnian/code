     public class ConsumerNM
     {
            //This is not a PK
            //[Key]
            //[Column(Order = 0)]
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int FK_LEADMETA { get; set; }
    
            [Key]
            public int FK_LEADCONSUMER { get; set; }  
    }
