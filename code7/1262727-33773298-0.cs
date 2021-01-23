    public class ViewModel
    {
        public bool Prop1 { get; set; }
        public bool Prop2 { get; set; }
        public bool Use2 { get; set; }
        public bool Prop
        {
            get { return Use2 ? Prop2 : Prop1; }
            set
            {
                if (Use2)
                    Prop2 = value;
                else
                    Prop1 = value;
            }
        }
    }
