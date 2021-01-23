    public class Customer
    {
        public int Id { get; set; }
        private string firstName;
        public string FirstName 
        { 
            get { return firstName }
            set
            {
                if(value!=null && value.length<20)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException("The first name must have at maxium 20 characters", "value");
                }
            } 
        }
        public string LastName { get; set; }
    }
