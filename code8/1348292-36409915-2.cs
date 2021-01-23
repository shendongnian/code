    public class person
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string fullname => name + " " + lastname;
    }
