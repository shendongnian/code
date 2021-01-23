    public class DialogViewModel 
    {
        //  You can create this in DialogViewModel's constructor if you need to 
        //  give it parameters that won't be known until then. 
        private AAAViewModel _aaavm = new AAAViewModel();
        public AAAViewModel AAAVM
        {
            get { return _aaavm; }
            protected set {
                _aaavm = value;
                OnPropertyChanged(nameof(AAAVM));
            }
        }
