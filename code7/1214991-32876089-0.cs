    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Border_OnTouchDown(object sender, TouchEventArgs e)
        {
            Debug.WriteLine("Border_OnTouchDown");
            IsManipulationEnabled = false;
            e.TouchDevice.Capture(Border);
        }
        private void Border_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Border_OnMouseDown!");
            DragDrop.DoDragDrop((DependencyObject)sender, "", DragDropEffects.All);
        }
        protected override void OnManipulationStarted(ManipulationStartedEventArgs e)
        {
            Debug.WriteLine("OnManipulationStarted");
            base.OnManipulationStarted(e);
        }
        private void Border_OnTouchUp(object sender, TouchEventArgs e)
        {
            Border.ReleaseTouchCapture(e.TouchDevice);
            IsManipulationEnabled = true;
        }
    }
