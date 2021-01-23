        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage = "Pls Enter Only Charaters")]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "Name Length Minimun 3 is required")]
        public string Ename { get; set; }
        [DisplayName("Employee salary")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Pls Enter Only Numbers")]
        [Required(ErrorMessage = "salary is required")]
        [Range(3000, 10000000, ErrorMessage = "Salary must be between 3000 and 10000000")]
        public int salary { get; set; }
        [DisplayName("Image")]
        [Required(ErrorMessage = "Image is required")]
        public HttpPostedFileBase Image { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage ="Please Enter Valid EmailID")]
        public string Email { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("ConfirmPassword")]
        [Required(ErrorMessage = "Password is required")]
        [Compare("Password", ErrorMessage = "Password is Not Matching")]
        public string ConfirmPassword { get; set; }
        [DisplayName("PHONENumber")]
        [Required(ErrorMessage = "PhoneNmber is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Pls Enter Only Numbers")]
        [StringLength(10,ErrorMessage ="maxlimit 10")]
        public string PhoneNmber { get; set; }
        [DisplayName("Age")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Pls Enter Only Numbers")]
        [Required(ErrorMessage = "Age is required")]
        public int Age { set; get; }
        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public bool Gender { get; set; }
        [DisplayName("Date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime DateandTime { get; set; }
        [DisplayName("BookNames")]
        [Required(ErrorMessage = "Date is required")]
        public List<string> BookNames { get; set; }
     
}
