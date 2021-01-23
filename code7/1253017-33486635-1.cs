    public class ViewModel : PropertyChangedBase
    {
        private Data1 data1 = new Data1();
        private Data2 data2 = new Data2();
    
        private object current;
        private RelayCommand switchCommand;
    
        public ViewModel1()
        {
            switchCommand = new RelayCommand(() => Switch());
            Current = data1;
        }
    
        public ICommand SwitchCommand
        {
            get
            {
                return switchCommand;
            }
        }
    
        public IEnumerable<Color> Colors
        {
            get
            {
                List<Color> colors = new List<Color>();
                colors.Add(System.Windows.Media.Colors.Red);
                colors.Add(System.Windows.Media.Colors.Yellow);
                colors.Add(System.Windows.Media.Colors.Green);
    
                return colors;
            }
        }
    
        private void Switch()
        {
            if (Current is Data1)
            {
                Current = data2;
                return;
            }
    
            Current = data1;
        }
    
        public object Current
        {
            get
            {
                return current;
            }
            set
            {
                if (current != value)
                {
                    current = value;
                    NotifyOfPropertyChange("Current");
                }
            }
        }
    }
