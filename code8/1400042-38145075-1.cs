    public class Contact
     {   [Required(ErrorMessage="Please fill the following")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please Enter Correct Username")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Please provide valid email id")]
        public string email { get; set; }
        public List<Subject> subject { get; set; }
        [Required(ErrorMessage="Please fill the following")]
        public string message { get; set; }
        public int Selectedid { get; set; }
    }
