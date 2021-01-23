    namespace YourApp.Controls
    {
        public sealed class YourButton : Control
        {
            public YourButton()
            {
                this.DefaultStyleKey = typeof(YourButton);
            }
            public string Text
            {
                get { return (string)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }
            // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(YourButton), new PropertyMetadata(0));
        }
    }
