     public class MainContact: BaseContact
        {
            [Required]
            [StringLength(50)]
            public override string FirstName { get; set; }
    
            [Required]
            [StringLength(50)]
            public override string LastName { get; set; }
            
        }
    
        public class BaseContact
        {
            [StringLength(50)]
            public virtual string FirstName { get; set; }
    
            [StringLength(50)]
            public virtual string LastName { get; set; }
    
            string Position { get; set; }
        }
