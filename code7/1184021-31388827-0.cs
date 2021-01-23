    public class BaseJobOffer : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("File")
        public int FileId { get; set; }
        
        //or 
        [ForeignKey("FileId")
        public File File { get; set; }
    }
