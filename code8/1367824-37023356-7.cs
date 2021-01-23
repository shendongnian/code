    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowGridLinesCommand = new RelayCommand(ShowGridLineManageCommand);
            AreGridLineVisible = true;
        }
        private void ShowGridLineManageCommand()
        {
            AreGridLineVisible = !AreGridLineVisible;
        }
        public static readonly DependencyProperty AreGridLineVisibleProperty = DependencyProperty.Register(
            "AreGridLineVisible", typeof (bool), typeof (MainWindow), new PropertyMetadata(default(bool)));
        public bool AreGridLineVisible
        {
            get { return (bool) GetValue(AreGridLineVisibleProperty); }
            set { SetValue(AreGridLineVisibleProperty, value); }
        }
        public static readonly DependencyProperty ShowGridLinesCommandProperty = DependencyProperty.Register(
            "ShowGridLinesCommand", typeof (ICommand), typeof (MainWindow), new PropertyMetadata(default(ICommand)));
        public ICommand ShowGridLinesCommand
        {
            get { return (ICommand) GetValue(ShowGridLinesCommandProperty); }
            set { SetValue(ShowGridLinesCommandProperty, value); }
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
