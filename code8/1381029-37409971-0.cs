    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Rectangle rect = new Rectangle();
        rect.Fill = new SolidColorBrush(Colors.Green);
        rect.Stroke = new SolidColorBrush(Colors.Black);
        rect.Height = 100;
        rect.Width = 100;
        rect.StrokeThickness = 4;
        // here
        rect.MouseLeftButtonDown += rect_MouseLeftButtonDown;
        rect.MouseLeftButtonUp += rect_MouseLeftButtonUp;
        rect.MouseMove += rect_MouseMove;
   
        canvas.Children.Add(rect);
        // InitializeComponent();   <--- lose the InitializeComponent here, that's should only be called ones.. (in the constructor)
    }
