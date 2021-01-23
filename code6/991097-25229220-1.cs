    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace WpfMagic
    {
        public partial class ImageBoard : UserControl
        {
            public ImageBoard()
            {
                InitializeComponent();
            }
    
            private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                TextBlock tb = new TextBlock { Text = "*", FontSize = 20 };
    
                tb.SetValue(Canvas.TopProperty, e.GetPosition(canvas).Y);
                tb.SetValue(Canvas.LeftProperty, e.GetPosition(canvas).X);
    
                canvas.Children.Add(tb);
            }
        }
    }
