    public static class AnimationHelper
    {
        private static void AnimateOpacity(DependencyObject target, double from, double to)
        {
            var opacityAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(500)
            };
            Storyboard.SetTarget(opacityAnimation, target);
            Storyboard.SetTargetProperty(opacityAnimation, "Opacity");
            var storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);
            storyboard.Begin();
        }
        /// <summary>
        /// Fades in the given dependency object.
        /// </summary>
        /// <param name="target">The target dependency object to fade in.</param>
        public static void FadeIn(DependencyObject target)
        {
            AnimateOpacity(target, 0, 1);
        }
    }
