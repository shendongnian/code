    public class AccountForm
    {
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Status { get; set; }
        public Account CreateInstance()
        {
            return new Account()
            {
                Name = Name,
                Birthdate = Birthdate,
                Status = Status.Substring(0, 1)
            };
        }
    }
