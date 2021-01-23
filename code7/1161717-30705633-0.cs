    public partial class MainWindow : Window
        {
            private readonly IList<Ellipse> shapes;
            private Ellipse currentMovingShape;
            public MainWindow()
            {
                InitializeComponent();
                shapes = new List<Ellipse>();
            }
    
            private void canvasss_MouseEnter(object sender, MouseEventArgs e)
            {
                AddEllipse();
            }
    
            private void AddEllipse()
            {
                currentMovingShape = new Ellipse { Width = 50, Height = 50, Fill = Brushes.Black };
                currentMovingShape.IsHitTestVisible = false;
                canvasss.Children.Add(currentMovingShape);
                Canvas.SetLeft(currentMovingShape, Mouse.GetPosition(canvasss).X - 25);
                Canvas.SetTop(currentMovingShape, Mouse.GetPosition(canvasss).Y - 25);
            }
    
            private void canvasss_MouseLeave(object sender, MouseEventArgs e)
            {
                if (currentMovingShape != null)
                {
                    canvasss.Children.Remove(currentMovingShape);
                    currentMovingShape = null;
                }
            }
            private void Canvasss_MouseMove(object sender, MouseEventArgs e)
            {
                Canvas.SetLeft(currentMovingShape, e.GetPosition(canvasss).X - 25);
                Canvas.SetTop(currentMovingShape, e.GetPosition(canvasss).Y - 25);
            }
    
            private void Canvasss_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (currentMovingShape != null)
                {
                    currentMovingShape.IsHitTestVisible = true;
                    shapes.Add(currentMovingShape);
                    AddEllipse();
                }
                
            }
        }
