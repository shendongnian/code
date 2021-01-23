    public class User
    {
        public int userId { get; set; }
        public int cityId { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String gender { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String photo { get; set; }
        public DateTime? joinDate { get; set; }
        //public City city { get; set; }
        //public Country country { get; set; }
        public virtual City city { get; set; }
        private String FullName
        {
            get { return firstName + lastName; }
        }
    }
