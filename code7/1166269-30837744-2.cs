        public void AnimateFade(object sender, double opacity, double period)
        {
            UIElement element = (UIElement)sender;
            element.Opacity = 0;
            DoubleAnimation animation = new DoubleAnimation(opacity, TimeSpan.FromSeconds(period));
            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }
