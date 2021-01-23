    public class TeamNRegion
    {
        public string TeamName { get; set; }
        public string RegionName { get; set; }
        public int Id { get; set; }
    
        public override string ToString()
        {
            return String.Format("{0} is in the {1} region", this.TeamName, this.RegionName);
        }
    }
