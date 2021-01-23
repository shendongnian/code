    public class ViewModel //choose a name that fits the data/business case
    {
        public IList<UserInfo> UserInfo { get; set; }
    }
    public class UserInfoViewModel
    {
        //Note: your datatypes may vary
        public string Status { get; set; }
        public string Appropriation { get; set; }
        // continue with all other properties ...
    }
