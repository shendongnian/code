    class ContentControlBehavior : Behavior<TransitionElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.IsEnabledChanged += AssociatedObject_IsEnabledChanged;
            // add effect to element
            BlurEffect effect = new BlurEffect() { Radius = 0 };
            AssociatedObject.Effect = effect;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.IsEnabledChanged -= AssociatedObject_IsEnabledChanged;
            base.OnDetaching();
            //remove the effect
            AssociatedObject.Effect = null;
        }
        void AssociatedObject_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == false)
            {
                //Blur
                BlurEffect effect = AssociatedObject.Effect as BlurEffect;
                effect.BeginAnimation(BlurEffect.RadiusProperty, new DoubleAnimation(10, TimeSpan.FromSeconds(0.5)));
            }
            else
            {
                //UnBlur
                BlurEffect effect = AssociatedObject.Effect as BlurEffect;
                effect.BeginAnimation(BlurEffect.RadiusProperty, new DoubleAnimation(0, TimeSpan.FromSeconds(0.25)));
            }
        }
    }
