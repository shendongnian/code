         public ObservableCollection<string> NameTab
        {
            get { return (ObservableCollection<string>)GetValue(NameTabProperty); }
            set { SetValue(NameTabProperty, value); }
        }
        // Using a DependencyProperty as the backing store for NameTab.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameTabProperty =
            DependencyProperty.Register("NameTab", typeof(ObservableCollection<string>), typeof(MainWindow), new PropertyMetadata(null));
