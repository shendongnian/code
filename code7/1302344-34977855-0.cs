    public class SelectedBadge
    {
        public int badgeIndex { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
    
    public class RootObject
    {
        public List<SelectedBadge> selectedBadges { get; set; }
    }
    
