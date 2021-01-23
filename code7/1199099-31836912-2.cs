    public class Lender
    {
        public Lender(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
    public class AnObject
    {
        private Lender _lender;
        public dynamic Lender
        {
            get { return _lender; }
            set
            {
                _lender = value is string ? new Lender(value as string) : value as Lender;
            }
        }
    }
