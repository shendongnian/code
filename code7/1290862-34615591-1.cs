    [Table("TeacherSkills")]
    public class TeacherSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int TeacherID { get; set; }
   
        [ForeignKey("TeacherID ")]
        public Teacher Teacher { get; set; }
        [Required]
        public int SkillID{ get; set; }
        
        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }
    }
