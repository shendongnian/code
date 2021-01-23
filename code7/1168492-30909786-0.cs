    <UserControl x:Class="SomeNamespace.SomeUserControl" ...>
        ...
        <TextBlock Text="{Binding Text, RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl}" ...>
    </UserControl>
.
    public partial class SomeUserControl : UserControl
    {
        // simple dependency property to bind to
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SomeUserControl), new PropertyMetadata());
        // has some complicated logic
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(SomeUserControl),
            new PropertyMetadata((d, a) => ((SomeUserControl)d).ValueChanged()));
        private void ValueChanged()
        {
            ... // do something complicated here
                // e.g. create complicated dynamic animation
        }
        ...
    }
