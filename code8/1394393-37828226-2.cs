        public MainWindow()
        {
            InitializeComponent();
            this.label.MouseLeftButtonDown += control_MouseLeftButtonDown;
            this.label.MouseMove += control_MouseMove;
            this.label.MouseLeftButtonUp += control_MouseLeftButtonUp;
        }
        // Keep track of the Canvas where this element is placed.
        private Canvas canvas;
        // Keep track of when the element is being dragged.
        private bool isDragging = false;
        // When the element is clicked, record the exact position
        // where the click is made.
        private Point mouseOffset;
        private void control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label l = e.Source as Label;
            if (l == null)
                return;
            // Find the Canvas.
            if (canvas == null)
                canvas = (Canvas)VisualTreeHelper.GetParent(l);
            // Dragging mode begins.
            isDragging = true;
            // Get the position of the click relative to the element
            // (so the top-left corner of the element is (0,0).
            mouseOffset = e.GetPosition(l);
            // Capture the mouse. This way you'll keep receiving
            // the MouseMove event even if the user jerks the mouse
            // off the element.
            l.CaptureMouse();
        }
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            Label l = e.Source as Label;
            if (l == null)
                return;
            if (isDragging)
            {
                // Get the position of the element relative to the Canvas.
                Point point = e.GetPosition(canvas);
                // Move the element.
                l.SetValue(Canvas.TopProperty, point.Y - mouseOffset.Y);
                l.SetValue(Canvas.LeftProperty, point.X - mouseOffset.X);
            }
        }
        private void control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Label l = e.Source as Label;
            if (l == null)
                return;
            if (isDragging)
            {
                l.ReleaseMouseCapture();
                isDragging = false;
            }
        }
