    public class ModelView
    {
        public long ID { get; set; }
        [Display(Name = "Name")]
        public bool IsNameSelected { get; set; }
        [Display(Name = "Phone")]
        public bool IsPhoneSelected { get; set; }
        [Display(Name = "Address")]
        public bool IsAddressSelected { get; set; }
        // additional property to define if the form is for an Owner or Tenant
        public bool IsOwner { get; set; }
    }
