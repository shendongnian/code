    public class person
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public override string ToString()
        {
            return name + " " + lastname;
        }
    }
