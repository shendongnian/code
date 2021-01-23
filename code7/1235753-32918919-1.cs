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
    
    namespace WpfDrawing
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            double designWidth;
            double designHeight;
    
            double designLeft, designTop;
    
            public MainWindow()
            {
                InitializeComponent();
    
                designWidth = Rect2.Width;
                designHeight = Rect2.Height;
    
                designLeft = Canvas.GetLeft(Rect2);
                designTop = Canvas.GetTop(Rect2);
            }       
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Rect2.StrokeThickness = double.Parse(tbThickness.Text);
    
                Canvas.SetLeft(Rect2,designLeft - (Rect2.StrokeThickness / 2));
                Canvas.SetTop(Rect2, designTop - (Rect2.StrokeThickness / 2));                        
    
                Rect2.Width = designWidth + Rect2.StrokeThickness;
                Rect2.Height = designHeight + Rect2.StrokeThickness;
    
            }
        }
    }
