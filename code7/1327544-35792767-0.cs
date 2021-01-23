    public partial class Person
    {
        [Key]
        pubic long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public partial class Patient : Person
    {
        [Key, Column("Person_id")]
        public new long Id 
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        public string NickName { get; set; }
    }
