    [DataContract]
    public class CustomerUpdateDTO
    {
        
        private string firstName;
        public bool FirstNameSpecified { get; set; }
        ...
        [DataMember(Order = 1)]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                FirstNameSpecified = true;
                firstName = value;
            }
        }
        ...
    }
