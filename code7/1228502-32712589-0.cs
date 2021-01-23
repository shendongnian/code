    public class Properties
    {
        public IDictionary<string, string> ExtendedProperties
        {
            get;
            set;
        }
        public Properties()
        {
            this.ExtendedProperties["Name"] = String.Empty;
            this.ExtendedProperties["Number"] = String.Empty;
            this.ExtendedProperties["Age"] = String.Empty;
        }
    }
