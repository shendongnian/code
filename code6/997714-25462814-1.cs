    public partial class MouseMoveWatcher : UserControl
    {
        public MouseMoveWatcher()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            (App.Current.RootVisual as MainPage).MouseMove += MouseMoveWatcher_MouseMove;
        }
        void MouseMoveWatcher_MouseMove(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(App.Current.RootVisual);
            this.X.Text = String.Format("{0:f}", position.X);
            this.Y.Text = String.Format("{0:f}", position.Y);
        }
    }
