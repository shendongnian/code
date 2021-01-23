    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        public string Username { get; set; }
        public string Telphone { get; set; }
    }
    public class UserMetaData
    {
        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone number")]
        public string Telephone { get; set; }
    }
