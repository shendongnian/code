    class MainViewModel : INotifyPropertyChanged
        {
            private Brush _backGround = new SolidColorBrush(Colors.Red);
    
            public Brush BackGround
            {
                get { return _backGround; }
                set
                {
                    _backGround = value;
                    OnPropertyChanged();
                }
            }
    
            private Brush _backGroundOnHover;
            public Brush BackGroundOnHover
            {
                get
                {
                  if (_backGroundOnHover == null)
                        SetHoverBackGround();
                    Debug.WriteLine(((SolidColorBrush)_backGroundOnHover).Color.R);
                    return _backGroundOnHover;
                }
                set
                {
                    _backGroundOnHover = value;
                    OnPropertyChanged();
                }
            }
    
            private RelayCommand _buttonPressedCommand;
    
            public RelayCommand ButtonPressedCommand
            {
                get
                {
                    return _buttonPressedCommand ??
                           (_buttonPressedCommand = new RelayCommand(SetBackgroundWhenButtonPressed));
                }
            }
    
            private void SetBackgroundWhenButtonPressed()
            {
                var color = ((SolidColorBrush)BackGround).Color;
                BackGround = new SolidColorBrush(Color.FromRgb((byte)(color.R - 5), color.G, color.B));
                SetHoverBackGround();
            }
    
            private void SetHoverBackGround()
            {
                var color = ((SolidColorBrush)BackGround).Color;
                BackGroundOnHover = new SolidColorBrush(Color.FromRgb((byte)(255-color.R ), color.G, color.B));
            }
    
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
