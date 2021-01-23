    public sealed class Album
    {
        public static readonly Album Similiar = new Album("Similiar");
        public static readonly Album Tags = new Album("Tags");
        public string Value { get; private set; }
        private Album(string value)
        {
            this.Value = value;
        }
    }
