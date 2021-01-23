    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Demonstrate that children added from inside the code-behind are reflected.
            Rectangle newRectangle = new Rectangle() { Width = 50, Height = 50, Fill = Brushes.Orange };
            CanvasSource.Children.Add(newRectangle);
            Canvas.SetLeft(newRectangle, 100);
            Canvas.SetTop(newRectangle, 100);
            CanvasSource.PropertyChanged += CanvasSource_PropertyChanged;
            //Also, demonstrate that child property changes can be seen.
            DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                newRectangle.Fill = Brushes.Brown;
            };
            timer.Start();
        }
        //This event handler is called when a child is added to or removed from
        //the ObservableCanvas.
        private void CanvasSource_VisualChildrenChanged(object sender, RoutedEventArgs e)
        {
            ObservableCanvas source = sender as ObservableCanvas;
            if (source == null) return;
            CopyElements(source);
        }
        //This event handler is called when a child element of the ObservableCanvas
        //has a property that changes.
        void CanvasSource_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ObservableCanvas source = sender as ObservableCanvas;
            if (source == null) return;
            CopyElements(source);
        }
        //This event handler is used to ensure that the target Canvas
        //has the elements copied from the source when initialized.
        private void CanvasTarget_Loaded(object sender, RoutedEventArgs e)
        {
            CopyElements(CanvasSource);
        }
        //This function creates a brand new copy of the ObservableCanvas's
        //children and puts it into the target Canvas.
        private void CopyElements(ObservableCanvas source)
        {
            if (CanvasTarget == null) return;
            CanvasTarget.Children.Clear();  //Start from scratch.
            foreach (UIElement child in source.Children)
            {
                //We need to create a deep clone of the elements to they copy.
                //This is necessary since we can't add the same child to two different
                //UIlements.
                UIElement clone = (UIElement)XamlReader.Parse(XamlWriter.Save(child));
                CanvasTarget.Children.Add(clone);
            }
        }
    }
