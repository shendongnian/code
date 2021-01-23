    public class TipFocusAdorner : Adorner
    {
        public TipFocusAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
        }
        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            var root = Window.GetWindow(this);
            var adornerLayer = AdornerLayer.GetAdornerLayer(AdornedElement);
            var presentationSource = PresentationSource.FromVisual(adornerLayer);
            Matrix transformToDevice = presentationSource.CompositionTarget.TransformToDevice;
            var sizeInPixels = transformToDevice.Transform((Vector)adornerLayer.RenderSize);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)(sizeInPixels.X), (int)(sizeInPixels.Y), 96, 96, PixelFormats.Default);
            var oldEffect = root.Effect;
            var oldVisibility = AdornedElement.Visibility;
            root.Effect = new BlurEffect();
            AdornedElement.SetCurrentValue(FrameworkElement.VisibilityProperty, Visibility.Hidden);
            rtb.Render(root);
            AdornedElement.SetCurrentValue(FrameworkElement.VisibilityProperty, oldVisibility);
            root.Effect = oldEffect;
            drawingContext.DrawImage(rtb, adornerLayer.TransformToVisual(AdornedElement).TransformBounds(new Rect(adornerLayer.RenderSize)));
            drawingContext.DrawRectangle(new SolidColorBrush(Color.FromArgb(22, 0, 0, 0)), null, adornerLayer.TransformToVisual(AdornedElement).TransformBounds(new Rect(adornerLayer.RenderSize)));
            drawingContext.DrawRectangle(new VisualBrush(AdornedElement) { AlignmentX = AlignmentX.Left, TileMode = TileMode.None, Stretch = Stretch.None },
                null,
                AdornedElement.RenderTransform.TransformBounds(new Rect(AdornedElement.DesiredSize)));
        }
    }
