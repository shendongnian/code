    public class CustomerModel : PersonModel
    {
        public DateTime DateJoined { get; set; }
    }
    
    public abstract class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
