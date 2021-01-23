    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : System.Attribute {
        public string FriendlyName { get; set; }
        public int Rank { get; set; }
    }
