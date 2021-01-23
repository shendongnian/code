            public class SomeModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _flag = false;
        /// <summary>
        /// This flag is your bool value.
        /// </summary>
        public bool Flag
        {
            get { return _flag; }
            set
            {
                if (_flag != value)
                {
                    _flag = value;
                    Notify();
                }
            }
        }
        private void Notify([CallerMemberName] string name = "")
        {
            var h = PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(name));
        }
    }
