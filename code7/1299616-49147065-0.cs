    public class Person {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    
        public override bool Equals(object other) {
            var otherPerson = other as Person;
            if (otherPerson == null) {
                return false;
            }
            return Firstname == otherPerson.Firstname
                && Lastname == otherPerson.Lastname
                && Birthdate == otherPerson.Birthdate;
        }
    }
