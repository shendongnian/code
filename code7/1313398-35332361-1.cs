    public class IDValidatorRange : Freezable
    {
        public static readonly DependencyProperty MinLengthProperty = DependencyProperty.Register(
            "MinLength", typeof (int), typeof (IDValidatorRange), new FrameworkPropertyMetadata(5, OnMinLengthChanged));
        public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register(
            "MaxLength", typeof (int), typeof (IDValidatorRange), new FrameworkPropertyMetadata(10, OnMaxLengthChanged));
        public void SetValidator(IDValidator validator)
        {
            Validator = validator;
            if (validator != null)
            {
                validator.MinLength = MinLength;
                validator.MaxLength = MaxLength;
            }
        }
        public int MaxLength
        {
            get { return (int) GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        public int MinLength
        {
            get { return (int) GetValue(MinLengthProperty); }
            set { SetValue(MinLengthProperty, value); }
        }
        private IDValidator Validator { get; set; }
        private static void OnMaxLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var range = (IDValidatorRange) d;
            if (range.Validator != null)
            {
                range.Validator.MaxLength = (int) e.NewValue;
            }
        }
        private static void OnMinLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var range = (IDValidatorRange) d;
            if (range.Validator != null)
            {
                range.Validator.MinLength = (int) e.NewValue;
            }
        }
        protected override Freezable CreateInstanceCore()
        {
            return new IDValidatorRange();
        }
    }
