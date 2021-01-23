    public class UserViewModel
    {
        public string Name { get; set; }
        public IList<string> Offices { get; private set; }
    
        public UserViewModel()
        {
            Offices = new List<string>
            {
                "Auckland",
                "Wellington",
                "Christchurch"
            };
        }
    }
