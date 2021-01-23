    public class Score
    {
        public int ScoreId{ get; set; }
        public int ApplicationUserId{ get; set; }
            
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser{ get; set; }
    }
