    public class Stage {
        public int ID { get; set; }
        public int NextStageID { get; set; }
        public string Name { get; set; }
        [ForeignKey("NextStageID ")]
        public virtual Stage NextStage { get; set;}
    }
