      using System.Windows.Media.Imaging;
      using System.Windows.Navigation;
      using System.Windows.Shapes;
    
      namespace WpfApplication8
      {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
            }
        public IEnumerable<string> EnvironmentVersions
        {
            get { return (IEnumerable<string>)GetValue(EnvironmentVersionsProperty); }
            set { SetValue(EnvironmentVersionsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for EnvironmentVersions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnvironmentVersionsProperty =
            DependencyProperty.Register("EnvironmentVersions", typeof(IEnumerable<string>), typeof(UserControl1), new PropertyMetadata(default(IEnumerable<string>)));
        }
    }
