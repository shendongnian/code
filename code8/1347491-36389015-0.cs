    class AttachStoryboard
    {
        public RoutedEvent Trigger { get; set; }
        public Storyboard Storyboard { get; set; }
        public event EventHandler Completed;
        public void RaiseCompleted()
        {
            EventHandler handler = Completed;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
    static class StoryboardHelper
    {
        public static readonly DependencyProperty AttachStoryboardProperty = DependencyProperty.RegisterAttached(
            "AttachStoryboard", typeof(AttachStoryboard), typeof(StoryboardHelper), new PropertyMetadata(_OnAttachStoryboardChanged));
        private static void _OnAttachStoryboardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement target = (FrameworkElement)d;
            AttachStoryboard attachStoryboard = (AttachStoryboard)e.NewValue;
            if (attachStoryboard != null)
            {
                BeginStoryboard beginStoryboard = new BeginStoryboard { Storyboard = attachStoryboard.Storyboard };
                EventTrigger trigger = new EventTrigger(attachStoryboard.Trigger);
                trigger.Actions.Add(beginStoryboard);
                attachStoryboard.Storyboard.Completed += (sender, e1) => attachStoryboard.RaiseCompleted();
                target.Triggers.Add(trigger);
            }
        }
        public static void SetAttachStoryboard(FrameworkElement target, AttachStoryboard value)
        {
            target.SetValue(AttachStoryboardProperty, value);
        }
        public static AttachStoryboard GetAttachStoryboard(FrameworkElement target)
        {
            return (AttachStoryboard)target.GetValue(AttachStoryboardProperty);
        }
    }
