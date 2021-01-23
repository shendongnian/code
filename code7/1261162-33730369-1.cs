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
    
    namespace Q7
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                listView.ItemsSource = new String[] { "A", "B", "C", "D" };
            }
            protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
            {
                var track = ((ListViewItem)sender).Content;
                MessageBox.Show(track.ToString());
            }
        }
    }
    
