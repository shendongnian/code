    public class ViewModelListStuff : SomeBaseClass
    {
        private string name;
        public ICommand PreviewMouseLeftButtonDownCommand { get; set; }
        public ICommand KeyUpCommandnCommand { get; set; }
        public String Name
        {
            get { return name; }
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged();
            }
        }
        public ViewModelListStuff() 
        {
            InitStuff();
        }
        public void InitStuff()
        {
            PreviewMouseLeftButtonDownCommand = new RelayCommand<MouseButtonEventArgs>(PreviewMouseLeftButtonDown);
            KeyUpCommandnCommand = new RelayCommand<KeyEventArgs>(KeyUp);
        }
        private void KeyUp(KeyEventArgs e)
        {
            // Do your stuff here...
        }
        private void PreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            // Do your stuff heere
        }
    }
