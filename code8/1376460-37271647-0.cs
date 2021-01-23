    public class criterias
    {
        public double values { get; set; }
        public double time { get; set; }
    }
    
    public class movChannels
    {
        public movChannels
        {
            criteria = new List<criterias>();
        }
        public string name { get; set; }
        public IList<criterias> criteria { get; set; }
    }
    
    public class stepsList
    {
        public stepsList
        {
            stepChannelsCriteria = new List<movChannels>();
        }
        public string steps { get; set; }
        public IList<movChannels> stepChannelsCriteria { get; set; }
    }
    
    public class vehicles
    {
        public vehicles
        {
            vehValCriteria = new List<stepsList>();
        }
        public int vehID { get; set; }
        public string vehDescription { get; set; }
        public IList<stepsList> vehValCriteria { get; set; }
        public movChannels movments { get; set; }
    }
