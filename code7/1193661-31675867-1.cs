    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    
    namespace WpfApplication5
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Image img = new Image();
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "chart2 - Copy.png";
                img.Source = new BitmapImage(new Uri(path));
    
                StackPanel stackPnl = new StackPanel();
                stackPnl.Orientation = Orientation.Horizontal;
                stackPnl.Margin = new Thickness(10);
                stackPnl.Children.Add(img);
    
                button1.Content = stackPnl;
            }
        }
    }
