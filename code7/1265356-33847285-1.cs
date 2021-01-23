    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace WpfApplication13
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new VmMainWindow();
            }
    
            private void Image_MouseEnter(object sender, MouseEventArgs e)
            {
                ((VmItemInGrid)((Image)sender).DataContext).GetNextFile();
            }
        }
    }
