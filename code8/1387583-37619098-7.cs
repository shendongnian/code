    public class RubberBandBehavior : Behavior<ListBox>
    {
        private RubberBandAdorner band;
        private AdornerLayer adornerLayer;
    
        public static bool GetIsActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsActiveProperty);
        }
        public static void SetIsActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsActiveProperty, value);
        }
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(RubberBandBehavior), new PropertyMetadata(IsActiveProperty_Changed));
    
        private static void IsActiveProperty_Changed(DependencyObject sender,
            DependencyPropertyChangedEventArgs args)
        {
            RubberBandBehavior rubberBandBehavior = (RubberBandBehavior)sender;
            if (args.Property.Name == "IsActive")
            {
                bool newIsActiveValue = (bool)args.NewValue;
                if (rubberBandBehavior.AssociatedObject != null)
                {
                    if (newIsActiveValue == true)
                    {
                        rubberBandBehavior.AttachBehavior();
                    }
                    else
                    {
                        rubberBandBehavior.DetachBehavior();
                    }
                }
            }
        }
    
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            base.OnAttached();
        }
    
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.GetValue(IsActiveProperty).Equals(true))
            {
                AttachBehavior();
            }
        }
    
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            base.OnDetaching();
        }
    
        private void AttachBehavior()
        {
            band = new RubberBandAdorner(AssociatedObject);
            adornerLayer = AdornerLayer.GetAdornerLayer(AssociatedObject);
            adornerLayer.Add(band);
        }
    
        private void DetachBehavior()
        {
            adornerLayer.Remove(band);
        }
    }
