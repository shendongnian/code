    public static readonly DependencyProperty TerminDataProperty = DependencyProperty.Register(
            "TerminData", typeof (List<TerminDate>), typeof (ShowDirectUrlView), new PropertyMetadata(default(List<TerminDate>), TerminDataPropertyChanged));
        private static void TerminDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TerminView;
            if (control != null)
                control.TerminData = // Do here the logic if you what when this propety changes.
        }
        public List<TerminDate> TerminData
        {
            get { return (List<TerminDate>) GetValue(TerminDataProperty); }
            set { SetValue(TerminDataProperty, value); }
        }
