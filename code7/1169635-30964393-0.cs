    var binding = new Binding
            {
                Source = _sectionHeaderSlider,
                Mode = BindingMode.TwoWay,
                Path = new PropertyPath("Value"),
            };
            BindingOperations.SetBinding(ScrollTransform, Windows.UI.Xaml.Media.CompositeTransform.TranslateXProperty, binding);
