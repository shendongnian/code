    public class ContactFormViewModel
    {
        private Random Random { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public int Val1 { get; set; }
        public int Val2 { get; set; }
    
        public ContactFormViewModel()
        {
            Val1 = Random.Next(1,9);
            Val2 = Random.Next(6,19);
        }
    }
