     public partial class ColorPicker : UserControl, INotifyPropertyChanged
        {
            List<Color> _myColors = new List<Color>() 
            { Colors.Yellow, Colors.Green, Colors.Orange, Colors.Red };
    
            public Color SelectedColor
            {
                get { return (Color)GetValue(SelectedColorProperty); }
                set { SetValue(SelectedColorProperty, value); OnPropertyChanged("SelectedColor"); }
            }
    
    
            public static readonly DependencyProperty SelectedColorProperty =
                DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorPicker), new PropertyMetadata(null));        
    
            public ColorPicker()
            {
                InitializeComponent();
                SelectedColor = _myColors[0];
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                int index = _myColors.IndexOf(SelectedColor);
                if (index == _myColors.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
    
                SelectedColor = _myColors[index];
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
    
            public void OnPropertyChanged(String propname)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propname));
                }
            }
        }
