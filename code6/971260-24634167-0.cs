    public interface ISocialHuman{
        public int PersonID { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }
    public static void writeHumanSomewhere(ISocialHuman){
        StringBuilder lineBuilder = new StringBuilder();
        lineBuilder.Append("\"");
        lineBuilder.Append(p.PersonID);
        lineBuilder.Append("\",\"");
        lineBuilder.Append(p.Title);
        lineBuilder.Append("\",\"");
        lineBuilder.Append(p.Forename);
        lineBuilder.Append("\",\"");
    }
