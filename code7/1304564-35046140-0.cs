    public class CanvasGraph : Canvas
    {
        public CanvasGraph()
        {
            Focusable = true;
            Loaded += OnCanvasGraphLoaded;
        }
    
        private void OnCanvasGraphLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Focus();
            Loaded -= OnCanvasGraphLoaded;
        }
    
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Enter)
            {
                Console.WriteLine("context menu open");
                e.Handled = true;
            }
        }
    }
