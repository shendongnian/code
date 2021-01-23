        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }
        public MainWindowViewModel()
        {
            ButtonCommand=new RelayCommand<Grid>(ChangeBgColor);
        }
        public void ChangeBgColor(Grid grid)
        {
            if(grid!=null)
                grid.Background = Brushes.Red; //Any color you want to change.
        }
