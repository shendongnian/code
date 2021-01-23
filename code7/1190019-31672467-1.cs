        public MainWindow()
        {
            InitializeComponent();
        }
        private bool isTextEditing;
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isTextEditing)
            {
                TextBox.Visibility = Visibility.Visible;
                isTextEditing = true;
            }
            else
            {
                isTextEditing = false;
            }
        }
        private void OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            // As long as your TextBox.Visibility is Collapsed and the user is in 'textEditing' after the
            // first click, don't handle clicks in the Canvas
            if (!isTextEditing && TextBox.Visibility == Visibility.Visible)
            {
                Point clickPoint = e.GetPosition(PositioningCanvas);
                Canvas.SetTop(TextBox, clickPoint.Y);
                Canvas.SetLeft(TextBox, clickPoint.X);
            }
        }
