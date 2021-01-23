    using System.Windows;
    using System.Windows.Controls;
    namespace TestSO33289488UserControlUnloaded
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
            private void UserControl_Unloaded(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("UserControl.Unloaded was raised");
            }
        }
    }
