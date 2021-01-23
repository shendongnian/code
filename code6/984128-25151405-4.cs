    public class ShowHideDescriptionBehavior : DependencyObject, IBehavior
    {
        public string TextBlockName
        {
            get { return (string)GetValue(TextBlockNameProperty); }
            set { SetValue(TextBlockNameProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for TextBlockName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextBlockNameProperty =
            DependencyProperty.Register("TextBlockName", typeof(string), typeof(ShowHideDescriptionBehavior), new PropertyMetadata(string.Empty));
    
        public DependencyObject AssociatedObject { get; set; }
    
        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
            var panel = (Panel)this.AssociatedObject;
    
            panel.Holding += AssociatedObject_Holding;
            panel.Tapped += AssociatedObject_Tapped;
        }
    
        private void AssociatedObject_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(300),
                To = 0
            };
            Storyboard.SetTarget(animation, this.DescriptionTextBlock);
            Storyboard.SetTargetProperty(animation, "Opacity");
    
            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    
        private void AssociatedObject_Holding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
        {
            var animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromMilliseconds(300),
                To = 0.8
            };
            Storyboard.SetTarget(animation, this.DescriptionTextBlock);
            Storyboard.SetTargetProperty(animation, "Opacity");
    
            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    
        private TextBlock _descriptionTextBlock;
        private TextBlock DescriptionTextBlock
        {
            get
            {
                if (_descriptionTextBlock == null)
                {
                    var panel = (Panel)this.AssociatedObject;
                    // todo: add validation
                    _descriptionTextBlock = (TextBlock)panel.FindName(this.TextBlockName);
                }
    
                return _descriptionTextBlock;
            }
        }
    
        public void Detach()
        {
            var panel = (Panel)this.AssociatedObject;
    
            panel.Holding -= AssociatedObject_Holding;
            panel.Tapped -= AssociatedObject_Tapped;
        }
    }
