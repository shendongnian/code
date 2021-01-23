    public class StatusDefault : Status
    {
        public override Color Color { get; } = Color.White;
        protected override string Pattern { get; } = string.Empty;
        public override int GetIndex(string lookup)
        {
            return -1;
        }
    }
