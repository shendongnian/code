        [System.ComponentModel.DataAnnotations.Schema.Table("Skills")]
        public class Skill
        {
            [key]
            public int ID { get; set; }
            public string SkillName { get; set; }
    
            public virtual List<Teacher> Teachers { get; set; }
        }
    
       [System.ComponentModel.DataAnnotations.Schema.Table("Teachers")]
        public class Teacher
        {
            [key]
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Campus { get; set; }
    
            public virtual List<Skill> Skills { get; set; }
        }
