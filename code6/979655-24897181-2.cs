    public class RegisterVM
    {
        [Required]  
        [Remote("IsAvailable", "Validation")]      
        public override string UserName { get; set; }
    }
