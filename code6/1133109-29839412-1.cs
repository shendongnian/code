        public class lp_Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccountSkillId { get; set; }
        public int AccountId { get; set; }
        public int SkillId { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public string Description { get; set; }
        public string Rel { get; set; }
        public string Href { get; set; }
    }
