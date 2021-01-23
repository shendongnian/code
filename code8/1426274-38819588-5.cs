    namespace WpfTrash
    {
        /// <summary>
        /// Interaction logic for Test.xaml
        /// </summary>
        public partial class Test : Window
        {
            MyClass vm = new MyClass();
            public Test()
            {
                InitializeComponent();
                this.DataContext = vm;
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                var selecteditem = (TheEnum)Enum.Parse(typeof(TheEnum), cboTheEnum.SelectedItem.ToString(), true);
            }
        }
    }
