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
    
    namespace WpfApplication15
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                int count = 1;
                
    
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        Button MyControl1 = new Button();
                        MyControl1.Content = count.ToString();
                        MyControl1.Name = "Button" + count.ToString();
    
                        Grid.SetColumn(MyControl1, j);
                        Grid.SetRow(MyControl1, i);
                        gridMain.Children.Add(MyControl1);
    
                        count++;
                    }
    
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Button b = (Button)sender;
                
            }
    
    
        }
    }
