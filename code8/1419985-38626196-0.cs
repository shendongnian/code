    public abstract class Status
    {
        public abstract Color Color { get; }
        public abstract string Pattern { get; }
        public int GetIndex(string lookup)
        {
            return lookup.IndexOf(Pattern);
        }
    }
    public class StatusSql : Status
    {
        public override Color Color{ get; } = Color.Red;
        public override string Pattern { get; } = "[SQL]";
    }
    public class StatusInfo : Status
    {
        public override Color Color { get; } = Color.White;
        public override string Pattern { get; } = "[INFO]";
    }
