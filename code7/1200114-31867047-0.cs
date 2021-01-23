    public ObservableCollection<string> progress_messages
        {
            get { return (ObservableCollection<string>)GetValue(progress_messagesProperty); }
            set { SetValue(progress_messagesProperty, value); }
        }
        public static readonly DependencyProperty progress_messagesProperty =
            DependencyProperty.Register("progress_messages", typeof(ObservableCollection<string>), typeof(AppState), new PropertyMetadata(new ObservableCollection<string>()));
