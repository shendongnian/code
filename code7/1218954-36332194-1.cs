    public class CustomerModel
    {
        [Required]
        private string mFirstName = “Not filled in yet”;
    
        public void SetFirstName(string firstName)
        {
            mFirstName = firstName;
        }
    }
