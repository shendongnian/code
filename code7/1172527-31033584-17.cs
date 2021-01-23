    public class DupInfo : INotifyPropertyChanged
    {
        private bool _ToDelete;
        public bool ToDelete
        {
            get { return _ToDelete; }
            set
            {
                _ToDelete = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ToDelete"));
            }
        }
        public string FullName { get; set; }
        public long Size { get; set; }
        public uint? CheckSum { get; set; }
        public string BaseDirectory { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
