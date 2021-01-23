    public partial class MainWindow : Window
        {
            Control draggedItem;
            Point itemRelativePosition;
            bool IsDragging;
            public MainWindow()
            {
                InitializeComponent();
                IsDragging = false;
            }
            
            private void btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                IsDragging = true;
                draggedItem = (Button)sender;
                itemRelativePosition = e.GetPosition(draggedItem);
            }
    
            private void btn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                if (!IsDragging)
                    return;
    
                IsDragging = false;
            }
    
            private void btn_PreviewMouseMove(object sender, MouseEventArgs e)
            {
                if (!IsDragging)
                    return;
    
                Point canvasRelativePosition = e.GetPosition(MyCanvas);
    
                Canvas.SetTop(draggedItem, canvasRelativePosition.Y - itemRelativePosition.Y);
                Canvas.SetLeft(draggedItem, canvasRelativePosition.X - itemRelativePosition.X);
            }
        }
