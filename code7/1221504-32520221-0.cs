    [TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
    public sealed class LabeledTextBox : Control, IParameterReturnable
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(LabeledTextBox), new PropertyMetadata(default(string)));
        public string Label
        {
            get { return this.GetValue(LabelProperty).ToString(); }
            set { this.SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(LabeledTextBox), new PropertyMetadata(default(string)));
        public string Value
        {
            get { return this.GetValue(ValueProperty).ToString(); }
            set { this.SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(LabeledTextBox), new PropertyMetadata(false));
        public string IsReadOnly
        {
            get { return this.GetValue(IsReadOnlyProperty).ToString(); }
            set { this.SetValue(IsReadOnlyProperty, value); }
        }
        public LabeledTextBox()
        {
            this.DefaultStyleKey = typeof(LabeledTextBox);
        }
        private TextBox _textBox;
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _textBox = GetTemplateChild("PART_TextBox") as TextBox;
            if (_textBox != null)
            {
                _textBox.TextChanged += TextBoxOnTextChanged;
            }
        }
        private void TextBoxOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            this.Value = _textBox.Text;
        }
        public LabeledTextBox(Parameter parameter)
        {
            this.Label = parameter.DisplayName;
            this.Value = parameter.DefaultValue ?? "";
            this.DefaultStyleKey = typeof(LabeledTextBox);
        }
        public string GetKey()
        {
            return this.Label;
        }
        public string GetValue()
        {
            return this.Value;
        }
    }
