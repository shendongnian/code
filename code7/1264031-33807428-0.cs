    public class Proyect{
        [Key]
        public int id {get;set;}
        public virtual List<Stage> stages {get;set;}
        [Not Mapped]
        public virtual List<int> stageIds {
            get {
                return stages == null ? null : stages.Select(t => t.id).ToList();
            }
        }
    }
    public class Stage{
        public int id {get;set;}
        [ForeignKey("id")]
        public virtual Proyect Proyect {get;set;
    }
