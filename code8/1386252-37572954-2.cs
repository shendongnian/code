    public class Effect
    {
        private string _action;
        public string Action
        {
            get { return _action; }
            set { _action = (value != null ? value.ToUpper() : null); }
        }
        public double Value { get; set; }
        private string _target;
        public string Target
        {
            get { return _target; }
            set { _target = (value != null ? value.ToUpper() : null); }
        }
        public Effect()
        {
        }
    }
