    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace WpfTest2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    
            public MainWindow()
            {
                InitializeComponent();
                dispatcherTimer.Tick += dispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
    
            }
    
            private void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                Button1.Margin = new Thickness(185, 61, 0, 0);
                dispatcherTimer.Stop();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                dispatcherTimer.Start();
                Button1.Margin = new Thickness(140, 61, 0, 0);
    
            }
        }
    }
