        public void AnimateFade(object sender, double opacity, double period)
        {
            UIElement win = (UIElement)sender;
            win.Opacity = 0;
            DoubleAnimation animation = new DoubleAnimation(opacity, TimeSpan.FromSeconds(period));
            win.BeginAnimation(UIElement.OpacityProperty, animation);
        }
