    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WPF_Test
    {
        public partial class MainWindow : Window
        {
            public static Button xamlStaticButton;
    
            public MainWindow()
            {
                InitializeComponent();
                xamlStaticButton = xaml_button;
                xamlStaticButton.Content = "Text changed on start";
            }
    
            private void xaml_button_Click(object sender, RoutedEventArgs e)
            {
                Threading.t1.Start();
                UIControl.ChangeButtonName("Updated from another CLASS.");
            }
        }
    }
