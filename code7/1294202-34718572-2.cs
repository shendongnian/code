    [Serializable]
    public sealed class ColumnOrderItem
    {
        public int DisplayIndex { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public int ColumnIndex { get; set; }
        public override string ToString()
        {
            StringBuilder overRideString = new StringBuilder();
            overRideString.AppendLine("DisplayIndex" + DisplayIndex.ToString());
            overRideString.AppendLine("Width" + Width.ToString());
            overRideString.AppendLine("Visible" + Visible.ToString());
            overRideString.AppendLine("ColumnIndex" + ColumnIndex.ToString());
            return overRideString.ToString();
        }
    }
