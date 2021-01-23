    class Core
    {
        private Canvas innerCanvas;
        public Core(Canvas canvas)
        {
            this.innerCanvas = canvas;
        }
        public void DrawSomething()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = Brushes.Red;
            ellipse.Width = 20;
            ellipse.Height = 20;
            ellipse.SetValue(Canvas.TopProperty,20d);
            ellipse.SetValue(Canvas.LeftProperty,20d);
            this.innerCanvas.Children.Add(ellipse);
        }
    }
