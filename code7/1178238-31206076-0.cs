	public partial class RecordSoundWindow : Window, INotifyPropertyChanged
    {
        private IAudioRecorder Recorder;
        public ObservableCollection<string> RecordingDevices { get; set; }
        public RecordSoundWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitRecorder();
        }
        private void InitRecorder()
        {
            RecordingDevices = new ObservableCollection<string>();
            Recorder = new AudioRecorder();
            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                RecordingDevices.Add(WaveIn.GetCapabilities(n).ProductName);
                OnMyPropertyChanged(() => RecordingDevices);
            }
            //cbDevices.ItemsSource = RecordingDevices;
            if (RecordingDevices.Count > 0)
                cbDevices.SelectedIndex = 0;
            Recorder.SampleAggregator.MaximumCalculated += OnRecorderMaximumCalculated;
        }
		
        public event PropertyChangedEventHandler PropertyChanged;
        // Raise the event that a property has changed in order to update the visual elements bound to it
        internal void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        //Converts the passed parameter to its name in string
        internal void OnMyPropertyChanged<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            OnPropertyChanged(expressionBody.Member.Name);
        }
	}
