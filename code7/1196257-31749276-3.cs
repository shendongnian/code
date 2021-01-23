    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MyUserControl.xaml
        /// </summary>
        public partial class MyUserControl : UserControl
        {
    
            public string MyText
            {
                get { return (string)GetValue(MyTextProperty); }
                set { SetValue(MyTextProperty, value); }
            }
    
            public static readonly DependencyProperty MyTextProperty =
                DependencyProperty.Register("MyText", typeof(string), typeof(MyUserControl), new FrameworkPropertyMetadata(null) { BindsTwoWayByDefault = true });
    
            public MyUserControl()
            {
                InitializeComponent();
            }
        }
    }
