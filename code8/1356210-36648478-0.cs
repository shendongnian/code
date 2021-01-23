    public class Material
    {
        public int Id { get; set; }  // from material table
        public string Name { get; set; }  // from material table
       public ICollection<ScheduleRow> ScheduleRows{ get; set; }
       
    }
    
    public class ScheduleRow
    {
        public int Id { get; set; }  // from *ScheduleRow table*
          public int SequenceNo { get; set; } // from *ScheduleRow* table
        
        public Material  Material { get; set; } 
    }
