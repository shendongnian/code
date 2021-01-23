    public sealed partial class FoodItemControl : UserControl
    {
        public EventHandler thumbnailClicked
        {
            get { return (EventHandler)GetValue(thumbnailClickedProperty); }
            set { SetValue(thumbnailClickedProperty, value); }
        }
        public static readonly DependencyProperty thumbnailClickedProperty =
      DependencyProperty.Register("thumbnailClicked", typeof(EventHandler),
        typeof(FoodItemControl), new PropertyMetadata(""));
        public FoodItemControl()
        {
            this.InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
        }
    }
