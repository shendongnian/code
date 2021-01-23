    public class Magnifier : Grid
    {
        public Magnifier() : base()
        {
            this.Canvas = new Canvas();
            Border border = new Border();
            border.HorizontalAlignment = HorizontalAlignment.Left;
            border.VerticalAlignment = VerticalAlignment.Top;
            border.Child = this.Canvas;
            border.BorderBrush = new SolidColorBrush(Colors.Red);
            border.BorderThickness = new Thickness(10);
            border.Background = new SolidColorBrush(Colors.Black);
            this.Children.Add(border);
            this.border = border;
        }
        public async Task<object> Update(int x, int y)
        {
            this.Visibility = Visibility.Visible;
            // changes the amount of magnification
            int magnification = 2;
            // render the preview of the target
            RenderTargetBitmap bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(this.Target);
            this.Canvas.Width = this.PreviewWidth;
            this.Canvas.Height = this.PreviewHeight;
            double w = this.PreviewWidth / (2 * magnification);
            double h = this.PreviewHeight / (2 * magnification);
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = bitmap;
            double scaleX = this.Target.ActualWidth / this.PreviewWidth;
            double scaleY = this.Target.ActualHeight / this.PreviewHeight;
            TransformGroup transform = new TransformGroup();
            TranslateTransform translate = new TranslateTransform();
            translate.X = -(x - w) / scaleX;
            translate.Y = -(y - h) / scaleY;
            transform.Children.Add(translate);
            ScaleTransform scale = new ScaleTransform();
            scale.ScaleX = scaleX * magnification;
            scale.ScaleY = scaleY * magnification;
            transform.Children.Add(scale);
            brush.Transform = transform;
            Rectangle rect = new Rectangle();
            rect.Width = this.PreviewWidth;
            rect.Height = this.PreviewHeight;
            rect.Fill = brush;
            this.Canvas.Children.Clear();
            this.Canvas.Children.Add(rect);
            Ellipse centerDot = new Ellipse();
            centerDot.Width = 6;
            centerDot.Height = 6;
            centerDot.Fill = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(centerDot, this.PreviewWidth / 2 - 3);
            Canvas.SetTop(centerDot, this.PreviewHeight / 2 - 3);
            this.Canvas.Children.Add(centerDot);
            return null;
        }
        public Canvas Canvas { get; set; }
        public int PreviewWidth { get; set; }
        public int PreviewHeight { get; set; }
        private Border border = null;
        public FrameworkElement Target { get; set; }
    }
