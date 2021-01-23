        public static readonly BindableProperty ProportionalSizeProperty =
                BindableProperty.Create(nameof(ProportionalSize),
                                        typeof(bool),
                                        typeof(CustomImage),
                                        default(bool),
                                        propertyChanged: OnProportionalSizeChanged);
        public bool ProportionalSize
        {
            get { return (bool)GetValue(ProportionalSizeProperty); }
            set { SetValue(ProportionalSizeProperty, value); }
        }
        private static void OnProportionalSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var customImage = bindable as CustomImage;
            if (customImage != null)
            {
                customImage.TrySize();
            }
        }
