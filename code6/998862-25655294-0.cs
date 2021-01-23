        static VisibilityAnimation()
        {
            // Here we "register" on Visibility property "before change" event
            var desc = DependencyPropertyDescriptor.FromProperty(UIElement.VisibilityProperty, typeof(FrameworkElement));
            desc.DesignerCoerceValueCallback += CoerceVisibility;
