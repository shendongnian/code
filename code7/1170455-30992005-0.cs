    public class HistoryList : List<HistoryItem> //   <-- Add List<HistoryItem>
    {    
        [XmlIgnore]
        public SortedList<DateTime, string> sl;
    
        [XmlIgnore]
        public int max;
    
        [XmlIgnore]
        public ComboBox c;
    }
