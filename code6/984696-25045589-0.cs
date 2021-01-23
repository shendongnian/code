    public class People
    {
        public String Name { get; set; }
    }
    public class CivilStatus
    {
        public bool Married { get; set; }
    }
    public class PeopleCivilStatus
    {
        public People Person { get; set; }
        public CivilStatus Status { get; set; }
    }
