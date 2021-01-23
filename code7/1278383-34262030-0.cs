    public sealed partial class CustomPopupControl : UserControl
    {
        public CustomPopupControl()
        {
            this.InitializeComponent();    
    
            Debug.WriteLine("CustomPopupControl");
        }
    
        private void OnPopupLoaded(object sender, RoutedEventArgs e)
        {
            this.Popup_Container.HorizontalOffset = (Window.Current.Bounds.Width - Grid_Child.ActualWidth) / 2;
            this.Popup_Container.VerticalOffset = (Window.Current.Bounds.Height - Grid_Child.ActualHeight) / 2;
        }
    
        internal void OpenPopup()
        {
            Debug.WriteLine("OpenPopup");
            Popup_Container.IsOpen = true;
    
            var currentFrame = Window.Current.Content as Frame;
            var currentPage = currentFrame.Content as Page;
            currentPage.IsHitTestVisible = false;
    
            Debug.WriteLine("OpenPopup Done");
        }
    
        private void OnLayoutUpdated(object sender, object e)
        {
            if (Grid_Child.ActualWidth == 0 && Grid_Child.ActualHeight == 0)
            {
                return;
            }
    
            double ActualHorizontalOffset = Popup_Container.HorizontalOffset;
            double ActualVerticalOffset = Popup_Container.VerticalOffset;
    
            double NewHorizontalOffset = (Window.Current.Bounds.Width - Grid_Child.ActualWidth) / 2;
            double NewVerticalOffset = (Window.Current.Bounds.Height - Grid_Child.ActualHeight) / 2;
    
            if (ActualHorizontalOffset != NewHorizontalOffset || ActualVerticalOffset != NewVerticalOffset)
            {
                Popup_Container.HorizontalOffset = NewHorizontalOffset;
                Popup_Container.VerticalOffset = NewVerticalOffset;
            }
        }
    }
