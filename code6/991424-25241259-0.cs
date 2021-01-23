     public class Form1
     {
        [Key]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Department", Prompt = "Please enter your department")]
        public string Department { get; set; }       
       public  Form1 Form1{ get; set; }
       public  Form2 Form2 { get; set; }
    }
       public class Form2
    {
        [Key]
        public long Id { get; set; }
        //Mobile Home Page
        public string Location1 { get; set; }
        [DataType(DataType.MultilineText)] 
        public  Form1 Form1Obj { get; set; }
    }
    public class Form3
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Rhombus")]
        public bool Rhombus { get; set; }
        public  Form2 Form2Obj { get; set; }
    }
       
