    public class Customer
    {
        public const int Name_Max = 30;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null && value.Length > Name_Max)
                    throw new ArgumentException();
                name = value;
            }
        }
    }
