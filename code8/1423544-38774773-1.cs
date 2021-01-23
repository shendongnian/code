    private double height;
        private double childheight;
        public SlidableControl()
        {
            this.InitializeComponent();
            height = Window.Current.Bounds.Height * 2 - 20;
            childheight = Window.Current.Bounds.Height - 20;
        }
        public static readonly DependencyProperty TopContentProperty = DependencyProperty.Register("TopContent", typeof(UIElement), typeof(SlidableControl), new PropertyMetadata(null));
        public UIElement TopContent
        {
            get { return (UIElement)GetValue(TopContentProperty); }
            set { SetValue(TopContentProperty, value); }
        }
        public static readonly DependencyProperty BottomContentProperty = DependencyProperty.Register("BottomContent", typeof(UIElement), typeof(SlidableControl), new PropertyMetadata(null));
        public UIElement BottomContent
        {
            get { return (UIElement)GetValue(BottomContentProperty); }
            set { SetValue(BottomContentProperty, value); }
        }
        public static readonly DependencyProperty MaxSlideHeightProperty = DependencyProperty.Register("MaxSlideHeight", typeof(double), typeof(SlidableControl), new PropertyMetadata(0.0));
        public double MaxSlideHeight
        {
            get { return (double)GetValue(MaxSlideHeightProperty); }
            set { SetValue(MaxSlideHeightProperty, value); }
        }
        private void SlidButton_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            scrollViewer.VerticalScrollMode = ScrollMode.Enabled;
        }
        private void SlidButton_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            scrollViewer.VerticalScrollMode = ScrollMode.Disabled;
        }
        private static double Y;
        private void SlidButton_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var delta = Y + e.Delta.Translation.Y;
            if (delta >= -(childheight - MaxSlideHeight))
            {
                Y = Y + e.Delta.Translation.Y;
            }
            else
            {
                Y = -(childheight - MaxSlideHeight);
            }
            if (delta < (-(childheight - MaxSlideHeight) / 2))
            {
                VisualStateManager.GoToState(this, "SlidButtonTop", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "SlidButtonBottom", true);
            }
            scrollViewer.ChangeView(null, -Y, null);
        }
