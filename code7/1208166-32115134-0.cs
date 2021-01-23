    public class VerifyLicensorModel
    {
        public int TempId { get; set; } 
        public string Licensor { get; set; } 
        public string Address { get; set; }
        public int LicensorId { get; set; }
        public int ActionId { get; set; }
        public List<SelectListItem> ActionOptions { get; set; }   
        public int ReferenceId { get; set; }
        public List<SelectListItem> ReferenceOptions { get; set; }   
    }
