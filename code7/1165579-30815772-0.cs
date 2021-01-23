        public static readonly DependencyProperty SourceImageResourceIdProperty = 
            DependencyProperty.Register("SourceImageResourceId", typeof(string), typeof(WaitingImageControl), new PropertyMetadata( string.Empty, OnSourcePathPropertyChanged ));
		private static void OnSourcePathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as WaitingImageControl).SourceImageResourceId = e.NewValue.ToString();
		}
