    public class Team 
    {
    	public int teamID { get; set; }
        public string teamName { get; set; }
    	[MaxLength]
        public string teamPicture { get; set; }
        public string description { get; set; }
        public string content { get; set; }
    }
