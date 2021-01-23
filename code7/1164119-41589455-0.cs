    public class CustomCheckbox : Image
    {
        private const string CheckboxUnCheckedImage = "checkbox_unchecked";
        private const string CheckboxCheckedImage = "checkbox_checked";
        public CustomCheckbox()
        {
            Source = CheckboxUnCheckedImage;
            var imageTapGesture = new TapGestureRecognizer();
            imageTapGesture.Tapped += ImageTapGestureOnTapped;
            GestureRecognizers.Add(imageTapGesture);
            PropertyChanged += OnPropertyChanged;
        }
        private void ImageTapGestureOnTapped(object sender, EventArgs eventArgs)
        {
            if (IsEnabled)
            {
                Checked = !Checked;
            }
        }
        /// <summary>
		/// The checked changed event.
		/// </summary>
        public event EventHandler<bool> CheckedChanged;
        /// <summary>
		/// The checked state property.
		/// </summary>
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create("Checked", typeof(bool), typeof(CustomCheckbox), false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);
        public bool Checked
        {
            get
            {
                return (bool)GetValue(CheckedProperty);
            }
            set
            {
                if (Checked != value)
                {
                    SetValue(CheckedProperty, value);
                    CheckedChanged?.Invoke(this, value);
                }
            }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e?.PropertyName == IsEnabledProperty.PropertyName)
            {
                Opacity = IsEnabled ? 1 : 0.5;
            }
        }
        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var checkBox = bindable as CustomCheckbox;
            if (checkBox != null)
            {
                var value = newValue as bool?;
                checkBox.Checked = value.GetValueOrDefault();
                checkBox.Source = value.GetValueOrDefault() ? CheckboxCheckedImage : CheckboxUnCheckedImage;
            }
        }
    }
    
