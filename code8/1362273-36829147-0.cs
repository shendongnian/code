       public class UserModel
    {
        [Required(ErrorMessage = "Please Enter Zip")]
        [Display(Name = "Email")]
        [RegularExpression(@"^(53119|53029|53214)", 
        ErrorMessage = "Please Enter Valid Zip")]
        public string ZipCode{ get; set; } 
    }
