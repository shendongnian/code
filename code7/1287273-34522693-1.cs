    using System.ComponentModel.DataAnnotations;
    public class MyModel
    {
        [Required(ErrorMessage = "Please fill in text box.")]
        [StringLength(62, ErrorMessage = "Text must be {0} characters or less.")]
        public string Foo { get; set; }
    }
