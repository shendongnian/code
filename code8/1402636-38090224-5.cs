    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication4
    {
        /// <summary>
        /// Interaction logic for UC_.xaml
        /// </summary>
        public partial class UC1 : UserControl
        {
            public UC1()
            {
                InitializeComponent();
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                Window parentWindow = Application.Current.MainWindow;
                if (parentWindow.GetType() == typeof(MainWindow))
                {
                    (parentWindow as MainWindow).Uc1.Visibility = Visibility.Collapsed;
                    (parentWindow as MainWindow).Uc2.Visibility = Visibility.Visible;
                }
            }
        }
    }
