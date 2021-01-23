    public class AnimationTrigger : DependencyObject
    {
        // Using a DependencyProperty as the backing store for IsTriggered.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTriggeredProperty =
            DependencyProperty.RegisterAttached("IsTriggered", typeof(bool), typeof(AnimationTrigger), new PropertyMetadata(false));
    }
