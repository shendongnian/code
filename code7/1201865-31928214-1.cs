    public class User
    {
        public virtual Guid Id { get; set; }
        // Map this one
        protected internal virtual IDictionary<string, string> RightsInternal { get; set; }
        
        // Use this one
        public virtual IDictionary<string, List<string>> Rights
        {
            get { return RightsInternal.ToDictionary(_ => _.Key, _ => _.Value.Split('|').ToList()); }
            set { RightsInternal = value.ToDictionary(_ => _.Key, _ => string.Join("|", _.Value)); }
        }
    }
