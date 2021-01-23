    public class employee
    {
        [Key]
        public int id { get; set; }
        ....
        [Required]
        [Remote("doesCnicExist", "employee", AdditionalFields = "id", HttpMethod = "POST", ErrorMessage = "A user with this cnic already exists. Please enter a different cnic.")]
        public string cnic { get; set; }
    }
