    public class sample_data : INotifyPropertyChanged
    {
        // Create the OnPropertyChanged method to raise the event
        public event PropertyChangedEventHandler PropertyChanged;         
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public sample_data(string name)
        {
            this.Name = name;
            this.IsSelected = false;
            this.NonHighlightColor = new SolidColorBrush(Colors.Transparent);
            this.HighLightColor = new SolidColorBrush(Colors.Red);
        }      
        public string Name { get; set; }
        
        private bool _is_selected;
        public bool IsSelected
        {
            get { return _is_selected; }
            set
            {
                _is_selected = value;
                OnPropertyChanged("HighlightBackgroundColor");
            }
        }
        public SolidColorBrush HighlightBackgroundColor
        {
            get { if (IsSelected) return HighLightColor; else return NonHighlightColor; }
        }
        private SolidColorBrush HighLightColor{ get; set; }
        private SolidColorBrush NonHighlightColor { get; set; }
    }
