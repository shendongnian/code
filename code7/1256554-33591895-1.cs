    public class ResizeHandlingBehavior:Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SizeChanged += AssociatedObjectOnSizeChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SizeChanged -= AssociatedObjectOnSizeChanged;
        }
        private void AssociatedObjectOnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            var action = OnResizeAction;
            if(action == null) return;
            action(args);
        }
        public static readonly DependencyProperty OnResizeActionProperty = DependencyProperty.Register(
            "OnResizeAction", typeof (Action<object>), typeof (ResizeHandlingBehavior), new PropertyMetadata(default(Action<object>)));
        public Action<object> OnResizeAction
        {
            get { return (Action<object>) GetValue(OnResizeActionProperty); }
            set { SetValue(OnResizeActionProperty, value); }
        }
    }
