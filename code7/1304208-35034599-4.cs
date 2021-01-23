    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {           
            InitializeComponent();
            MyRect = new TabControl.MyRect();            
        }
        private MyRect myRect;
        public MyRect MyRect
        {
            get { return myRect; }
            set { myRect = value; RaiseChange("MyRect");}
        }             
        private void MySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MyRect != null)
            {
                MyRect.Height = e.NewValue/10;
                MyRect.Width = e.NewValue/10;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
