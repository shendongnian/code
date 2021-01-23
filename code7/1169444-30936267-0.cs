     public class User
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
            [Column(Order = 1)]
            public long N { get; set; }
            [Required]
            [Column(Order = 2)]
            public string Id { get; set; }   
            public string Login { get; set; }    
            public string Password { get; set; }    
            public int AccountRole { get; set; } 
        }
