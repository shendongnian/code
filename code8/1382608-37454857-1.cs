    public class Person
    {
        // DateOfBirth is NOT nullable - everyone has a date of birth...
        public DateTime DateOfBirth { get; set; }
        // DateOfDeath IS nullable - not everyone is dead yet...
        public DateTime? DateOfDeath { get; set; }
    }
