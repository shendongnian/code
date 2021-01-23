    public partial class tePerson
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> OrderId { get; set; }
    
        public virtual teOrder teOrder { get; set; }
    }
