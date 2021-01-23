    public class DateHolder
    {
        public enum DHGroups { A, B }
    
        public DHGroups Group { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
    
        public void SetGroup()
        {
            // Work with Date1 and Date2 to determine the Group
        }
    }
