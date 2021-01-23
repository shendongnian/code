    public sealed partial class MainPage : Page
    {
        GestureRecognizer gestureRecognizer = new GestureRecognizer();
        public MainPage()
        {
            this.InitializeComponent();
            gestureRecognizer.GestureSettings = Windows.UI.Input.GestureSettings.HoldWithMouse;         
        }
        void gestureRecognizer_Holding(GestureRecognizer sender, HoldingEventArgs args)
        {
            MyTextBlock.Text = "Hello";
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gestureRecognizer.Holding += gestureRecognizer_Holding;
        }
        private void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var ps = e.GetIntermediatePoints(null);
            if (ps != null && ps.Count > 0)
            {
                gestureRecognizer.ProcessDownEvent(ps[0]);
                e.Handled = true;
            }
        }
        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            gestureRecognizer.ProcessMoveEvents(e.GetIntermediatePoints(null));
            e.Handled = true;
        }
        private void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var ps = e.GetIntermediatePoints(null);
            if (ps != null && ps.Count > 0)
            {
                gestureRecognizer.ProcessUpEvent(ps[0]);
                e.Handled = true;
                gestureRecognizer.CompleteGesture();
            }
        }
    }
