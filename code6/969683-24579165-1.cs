    public class ProduceViewModel : ViewModel
    {
        public ProduceViewModel()
        {
            this.ProduceType = ProduceType.Apples;
        }
        private ProduceType _produceType;
        public ProduceType ProduceType
        {
            get
            {
                return _produceType;
            }
            set
            {
                if (_produceType != value)
                {
                    _produceType = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
