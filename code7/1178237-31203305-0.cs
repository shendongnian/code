    public ObservableCollection<string> RecordingDevices
        {
            get { return (ObservableCollection<string>)GetValue(RecordingDevicesProperty); }
            set { SetValue(RecordingDevicesProperty, value); }
        }
        // Using a DependencyProperty as the backing store for RecordingDevices.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RecordingDevicesProperty =
            DependencyProperty.Register("RecordingDevices", typeof(ObservableCollection<string>), typeof(RecordSoundWindow2), new PropertyMetadata(null));
