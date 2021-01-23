    public sealed class B: A
    {
        public override string Description
        {
            get
            {
                return "Custom_Description";
            }
            set
            {
               throw new InvalidOperationException();
            }
        }
    }
