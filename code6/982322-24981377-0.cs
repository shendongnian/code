    public class Grade
    {
        public int Points  { get; set; }
        public string Test { get; set; }
        public Grade()
        { Points = 0; Test = "No Test"; }
        public Grade(int points, string test)
        { Points = points; Test = test; }
    }
