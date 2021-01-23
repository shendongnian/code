    class PowersViewModel : BaseViewModel
    {
        double baseValue = 4;
        public PowersViewModel()
        { BaseValue = baseValue; }
        public double BaseValue
        {
            //private set - incorrect!
            set
            {
                SetProperty(ref baseValue, value);
            }
            get
            {
                return baseValue;
            }
        }
    }
