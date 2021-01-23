    class Class1
    {
        private string _pollo = "";
        public string pollo
        {
            get { return _pollo; }
            set
            {
                _pollo = value;
                Raise(polloChanged, this);
            }
        }
        private static void Raise(EventHandler handler, object sender)
        {
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }
        public event EventHandler polloChanged;
    }
