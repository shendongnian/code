    public interface Common{
      int ID { get; set; }
    }
    public class Animal : Common {
    [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]    
    public int ID { get; set; }
    public int NumberOfLegs { get; set; }
    }
    
    public class Dog : Common {
        public int ID { get; set; }
        public string OtherDogRelatedStuff { get; set; }
    }
