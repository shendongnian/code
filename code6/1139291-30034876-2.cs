    public sealed class ElementAnimator
    {
        private readonly UIElement _element;
        public ElementAnimator(UIElement element)
        {
            if (null == element)
            {
                throw new ArgumentNullException("element", "Element can't be null.");
            }
            _element = element;
        }
        public void AnimateToPoint(Point point, int durationInMilliseconds = 300)
        {
            var duration = new Duration(TimeSpan.FromMilliseconds(durationInMilliseconds));
            var easing = new BackEase
            {
                Amplitude = .3
            };
            var sb = new Storyboard
            {
                Duration = duration
            };
            var animateLeft = new DoubleAnimation
            {
                From = Canvas.GetLeft(_element),
                To = point.X,
                Duration = duration,
                EasingFunction = easing,
            };
            var animateTop = new DoubleAnimation
            {
                From = Canvas.GetTop(_element),
                To = point.Y,
                Duration = duration,
                EasingFunction = easing,
            };
            Storyboard.SetTargetProperty(animateLeft, "(Canvas.Left)");
            Storyboard.SetTarget(animateLeft, _element);
            Storyboard.SetTargetProperty(animateTop, "(Canvas.Top)");
            Storyboard.SetTarget(animateTop, _element);
            sb.Children.Add(animateLeft);
            sb.Children.Add(animateTop);
            sb.Begin();
        }
    }
