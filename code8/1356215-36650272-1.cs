    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ScheduleRow> ScheduleRows { get; set; } 
    }
    
    public class ScheduleRow 
    {
        public int Id { get; set; }
        public int SequenceNo { get; set; }
    
        public virtual Material Material { get; set; } 
    }
