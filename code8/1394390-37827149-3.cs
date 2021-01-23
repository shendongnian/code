    public TestApp()
    {
        InitializeComponent();
        txtBox.MouseDoubleClick+=new MouseButtonEventHandler(control_MouseDoubleClick);
        txtBox.MouseMove+=new MouseEventHandler(control_MouseMove);
        txtBox.PreviewMouseDown+=new MouseButtonEventHandler(control_PreviewMouseDown);
        txtBox.PreviewMouseUp+=new MouseButtonEventHandler(control_PreviewMouseUp);
        txtBox.Cursor = Cursors.SizeAll;
    }
    private void control_MouseMove(object sender, RoutedEventArgs e)
    {
        if (isClicked)
        {
            Point mousePos = Mouse.GetPosition(parentCanvas);
            parentItem = this.Parent as DesignerItem;
            parentCanvas = parentItem.Parent as DesignerCanvas;
            Point relativePosition = Mouse.GetPosition(parentCanvas);
            DesignerCanvas.SetLeft(this, DesignerCanvas.GetLeft(this) -  (startPoint.X - mousePos.X));
			DesignerCanvas.SetTop(this, DesignerCanvas.GetTop(this) - (startPoint.Y - mousePos.Y));
        }
    }
    private void control_PreviewMouseDown(object sender, RoutedEventArgs e)
    {
        if (!isClicked)
        {
            isClicked = true;
            parentItem = this.Parent as DesignerItem;
            parentCanvas = parentItem.Parent as DesignerCanvas;
            startPoint = Mouse.GetPosition(parentCanvas);
        }
    }
    private void control_PreviewMouseUp(object sender, RoutedEventArgs e)
    {
        isClicked = false;
    }
