    public class AccountProfile : IProfileInfo
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
    
    public interface IProfileInfo 
    {
        string Firstname {get;set;}
        string Lastname {get;set;}
    }
