    public class UserSickness {
        public int id { get; set; }
        public DateTime SicknessDate { get; set; }
        public List<Symptom> Symptoms { get; set; }
        
        // Navigation property
        public virtual User UserAsociated { get; set; }
    }
    public class Symptom {
        public int id { get; set; }
        public string Description { get; set; }
    
        // Navigation property
        public virtual UserSickness UserSicknessAsociated { get; set; }
    }
