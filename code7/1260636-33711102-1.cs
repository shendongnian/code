    private void bCustomPopup_Click(object sender, RoutedEventArgs e)
        {
            
            gridPopupOne.Height = Window.Current.Bounds.Height;
            gridPopupOne.Width = Window.Current.Bounds.Width;
            setPopup = true;
        }
        public static readonly DependencyProperty IsPopup = DependencyProperty.Register(
          "setPopup",
          typeof(bool),
          typeof(MainPage),
          new PropertyMetadata(false)
          );
        public bool setPopup
        {
            get { return (bool)GetValue(IsPopup); }
            set { SetValue(IsPopup, value); }
        }
        private void bCancelPopup_Click(object sender, RoutedEventArgs e)
        {
            setPopup = false;
        }
