    public class GrantUser
    {
        public Areas Area { get; set; }
        public string Level { get; set; }
        public GrantUser() { }
        public GrantUser(Areas Area, string Level)
        {
            this.Area = Area;
            this.Level = Level;
        }
    }
