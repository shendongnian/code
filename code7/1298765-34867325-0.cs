    public class Person
    {
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        //this should be first and second name together
        public String FullName{ get { return FirstName + " " + SecondName; } }
    }
