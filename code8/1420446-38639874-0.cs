     public class RectItem : INotifyPropertyChanged
        {
            private int _width;
            private int _height;
            private int _x;
            private int _y;
    
            public Brush Color { get; set; }
    
            public int Width {
                get { return _width; }
                set {
                    if (value == _width) return;
                    _width = value;
                    OnPropertyChanged();
                }
            }
    
            public int Height {
                get { return _height; }
                set {
                    if (value == _height) return;
                    _height = value;
                    OnPropertyChanged();
                }
            }
    
            public int X {
                get { return _x; }
                set {
                    if (value == _x) return;
                    _x = value;
                    OnPropertyChanged();
                }
            }
    
            public int Y {
                get { return _y; }
                set {
                    if (value == _y) return;
                    _y = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        internal class ViewModel : INotifyPropertyChanged
        {
            public ViewModel()
            {
                this.RectItems.Add(new RectItem { Height = 100, Width = 100, X = 0, Y = 0, Color = Brushes.DeepPink });
                this.RectItems.Add(new RectItem { Height = 50, Width = 50, X = 100, Y = 100, Color = Brushes.DeepSkyBlue });
            }
    
            private double _panelWidth = 100;
            private double _panelHeight = 100;
            public ObservableCollection<RectItem> RectItems { get; } = new ObservableCollection<RectItem>();
    
    
            public ICommand IncreaseSizeCommand => new RelayCommand(x =>
            {
                this.PanelHeight = 200;
                this.PanelWidth = 200;
            });
    
            public double PanelWidth {
                get { return _panelWidth; }
                set {
                    if (value.Equals(_panelWidth)) return;
                    _panelWidth = value;
                    OnPropertyChanged();
                }
            }
    
            public double PanelHeight {
                get { return _panelHeight; }
                set {
                    if (value.Equals(_panelHeight)) return;
                    _panelHeight = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
