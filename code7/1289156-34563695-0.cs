    public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
                this.DataContext = this;
            }
    
            public string Text
            {
                get { return (string)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty TextProperty =
                DependencyProperty.Register("Text", typeof(string), typeof(UserControl1), new PropertyMetadata("unset"));
    
        }
