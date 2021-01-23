    public class EnumRadioButton : ItemsControl
    {
        public static readonly DependencyProperty EnumTypeProperty =
            DependencyProperty.Register(nameof(EnumType), typeof(Type), typeof(EnumRadioButton), new PropertyMetadata(null, EnumTypeChanged));
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(EnumRadioButton));
        public static readonly DependencyProperty RadioButtonStyleProperty =
            DependencyProperty.Register(nameof(RadioButtonStyle), typeof(Style), typeof(EnumRadioButton));
        public Type EnumType
        {
            get { return (Type)GetValue(EnumTypeProperty); }
            set { SetValue(EnumTypeProperty, value); }
        }
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public Style RadioButtonStyle
        {
            get { return (Style)GetValue(RadioButtonStyleProperty); }
            set { SetValue(RadioButtonStyleProperty, value); }
        }
        private static void EnumTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EnumRadioButton enumRadioButton = (EnumRadioButton)d;
            enumRadioButton.UpdateItems(e.NewValue as Type);
        }
        
        private void UpdateItems(Type newValue)
        {
            Items.Clear();
            if (!newValue.IsEnum)
            {
                throw new ArgumentOutOfRangeException(nameof(newValue), $"Only enum types are supported in {GetType().Name} control");
            }
            var enumerationItems = EnumerationItemProvider.GetValues(newValue);
            foreach (var enumerationItem in enumerationItems)
            {
                var radioButton = new RadioButton { Content = enumerationItem.Name, ToolTip = enumerationItem.Description };
                SetCheckedBinding(enumerationItem, radioButton);
                SetStyleBinding(radioButton);
                Items.Add(radioButton);
            }
        }
        private void SetStyleBinding(RadioButton radioButton)
        {
            var binding = new Binding
            {
                Source = this,
                Mode = BindingMode.OneWay,
                Path = new PropertyPath(nameof(RadioButtonStyle))
            };
            radioButton.SetBinding(StyleProperty, binding);
        }
        private void SetCheckedBinding(EnumerationItem enumerationItem, RadioButton radioButton)
        {
            var binding = new Binding
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                Path = new PropertyPath(nameof(SelectedItem)),
                Converter = new EnumToBooleanConverter(), // would be more efficient as a singleton
                ConverterParameter = enumerationItem.Value
            };
            radioButton.SetBinding(ToggleButton.IsCheckedProperty, binding);
        }
    }
