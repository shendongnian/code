    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int PersonID { get; set; }
        public Person(string fName, string lName, int id)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.PersonID = id;
        }
    }
