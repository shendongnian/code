    [Table("TeacherSkills")]
    public class TeacherSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int TeacherID { get; set; }
        [Required]
        public int SkillID{ get; set; }
       
    }
