    public partial class MyUserControl : UserControl
    {
        public string Text1
        {
            get { return (string)GetValue(Text1Property); }
            set { SetValue(Text1Property, value); }
        }
        public static readonly DependencyProperty Text1Property = DependencyProperty.Register("Text1", typeof(string), typeof(MyUserControl), new PropertyMetadata(string.Empty));
        public string Text2
        {
            get { return (string)GetValue(Text2Property); }
            set { SetValue(Text2Property, value); }
        }
        public static readonly DependencyProperty Text2Property = DependencyProperty.Register("Text2", typeof(string), typeof(MyUserControl), new PropertyMetadata(string.Empty));
        public string Text3
        {
            get { return (string)GetValue(Text3Property); }
            set { SetValue(Text3Property, value); }
        }
        public static readonly DependencyProperty Text3Property = DependencyProperty.Register("Text3", typeof(string), typeof(MyUserControl), new PropertyMetadata(string.Empty));
        public string Text4
        {
            get { return (string)GetValue(Text4Property); }
            set { SetValue(Text4Property, value); }
        }
        public static readonly DependencyProperty Text4Property = DependencyProperty.Register("Text4", typeof(string), typeof(MyUserControl), new PropertyMetadata(string.Empty));
        public MyUserControl()
        {
            InitializeComponent();
        }
    }
