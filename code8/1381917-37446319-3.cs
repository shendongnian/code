    public class Item
    {
        public Brush EntryColor { get; set; }
        public long SequenceNumber { get; set; }
        public string Text => $"Item {SequenceNumber}";
        public override string ToString()
        {
            return Text;
        }
    }
