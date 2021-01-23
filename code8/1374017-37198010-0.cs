    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public int AgeValue => Convert.ToInt32(Age);
    } 
