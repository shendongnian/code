    public class myClass
    {
        private Dictionary<string, object> Something = new Dictionary<string, object>();
        public object this[string i]
        {
            get { return Something[i]; }
            set { Something[i] = value; }
        }
    }
