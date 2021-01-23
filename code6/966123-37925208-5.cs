    public class CountyViewModel
    {
        [HiddenInput]
        public int? CountyId { get; set; }
        [DisplayName("County Name")]
        [StringLength(25)]
        public string CountyName { get; set; }
        [DisplayName("Username")]
        [StringLength(255)]
        public string Username{ get; set; }
    }
