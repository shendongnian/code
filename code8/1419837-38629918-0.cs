     public TestBindingButton() : base()
        {
            this.Click += TestBindingButton_Click;
            var prop = DependencyPropertyDescriptor.FromProperty(ChoosenItemProperty, typeof(TestBindingButton));
            prop.AddValueChanged(this, SourceChangedHandler);
        }
