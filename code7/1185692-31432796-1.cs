    class Saving
    {
        private string _Prefix;
        public string Prefix
        {
            get
             {
                 return SavingsIndicatorEnum.AsString() + _Prefix
             }
             set
             {
                 _Prefix = value;
             }
        }
    }
