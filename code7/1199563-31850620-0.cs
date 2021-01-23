    public class MyViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Password")]
        public string Passsword { get; set; }
    } 
