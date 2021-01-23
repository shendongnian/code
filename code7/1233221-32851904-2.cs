    public class SomeControl : ContentControl
    {
        public static readonly DependencyProperty SomeProperty = DependencyProperty.Register("Some", typeof (int),
            typeof (SomeControl), new FrameworkPropertyMetadata(10) {Inherits = true});
        public int Some
        {
            get { return (int) GetValue(SomeProperty); }
            set { SetValue(SomeProperty, value); }
        }
    }
