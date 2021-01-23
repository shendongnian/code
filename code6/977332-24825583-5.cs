Extension class
    public static class DrawingContextExtension
    {
        public static void RenderBlurred(this DrawingContext dc, int width, int height, Rect targetRect, double blurRadius, Action<DrawingContext> action)
        {
            Rect elementRect = new Rect(0, 0, width, height);
            Placeholder element = new Placeholder(action)
            {
                Width = width,
                Height = height,
                Effect = new BlurEffect() { Radius = blurRadius }
            };
            element.Arrange(elementRect);
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            rtb.Render(element);
            dc.DrawImage(rtb, targetRect);
        }
        class Placeholder : FrameworkElement
        {
            Action<DrawingContext> action;
            public BlurredElement(Action<DrawingContext> action)
            {
                this.action = action;
            }
            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);
                action(drawingContext);
            }
        }
    }
