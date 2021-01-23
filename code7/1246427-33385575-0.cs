    public class LabelWithRequiredInfo : Label
    {
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsRequired.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(LabelWithRequiredInfo), new PropertyMetadata(false));
        static LabelWithRequiredInfo()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabelWithRequiredInfo), new FrameworkPropertyMetadata(typeof(LabelWithRequiredInfo)));
        }
    }
