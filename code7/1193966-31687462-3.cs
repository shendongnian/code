    namespace WpfApplication1
    {
        public class ViewModel : INotifyPropertyChanged
        {
            private int _currentAmount;
    
            public int CurrentAmount
            {
                get { return _currentAmount; }
                set
                {
                    _currentAmount = value;
                    OnPropertyChanged();
    
                    if (Buttons != null)
                    {
                        foreach (var button in Buttons)
                        {
                            if ((value - button.SubtractAmount) <= 0)
                            {
                                button.IsEnabled = false;
                            }
                        }
                    }
                }
            }
            public List<ButtonViewModel> Buttons { get; private set; }
    
            public ViewModel()
            {
                CurrentAmount = 1000;
    
                Buttons = new List<ButtonViewModel>
                {
                    new ButtonViewModel(this)
                    {
                        SubtractAmount = 1
                    },
                    new ButtonViewModel(this)
                    {
                        SubtractAmount = 5
                    },
                    new ButtonViewModel(this)
                    {
                        SubtractAmount = 15
                    },
                    new ButtonViewModel(this)
                    {
                        SubtractAmount = 30
                    }
                };
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
