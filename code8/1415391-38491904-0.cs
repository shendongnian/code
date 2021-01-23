    public class ResizingAdorner : Adorner
    {
        Thumb topLeft;
        // To store and manage the adorner's visual children.
        VisualCollection visualChildren;
        // Initialize the ResizingAdorner.
        public ResizingAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            visualChildren = new VisualCollection(this);
            // Call a helper method to initialize the Thumbs
            BuildAdornerCorner(ref topLeft, Cursors.SizeNWSE);
            //these are events for the thumbs you may want it or not according to your needs//
            topLeft.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(topLeft_PreviewMouseLeftButtonDown);
            topLeft.DragDelta += new DragDeltaEventHandler(HandleTopLeft);
        }
        //override this method for rendering
        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            // Some arbitrary drawing implements.
            SolidColorBrush RectBrush = new SolidColorBrush(Colors.Green);
            RectBrush.Opacity = 0.3;
            Pen renderPen = new Pen(RectBrush, 1.5);
            // Draw Rectangle
            drawingContext.DrawRectangle(null, renderPen, adornedElementRect);
        }
        // Arrange the Adorners.
        protected override Size ArrangeOverride(Size finalSize)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            // desiredWidth and desiredHeight are the width and height of the element that's being adorned.  
            // These will be used to place the ResizingAdorner at the corners of the adorned element.  
            double desiredWidth = adornedElementRect.BottomRight.X;
            double desiredHeight = adornedElementRect.BottomRight.Y;
            // adornerWidth & adornerHeight are used for placement as well.
            double adornerWidth = adornedElementRect.TopLeft.X;
            double adornerHeight = adornedElementRect.TopLeft.Y;
            //Arrange PathPoints with the helper Methods
            topLeft.Arrange(new Rect(new Point(adornerWidth, adornerHeight), new Point(desiredWidth, desiredHeight)));
            // Return the final size.
            return finalSize;
        }
        // set some appearance properties, and add the elements to the visual tree//
        void BuildAdornerCorner(ref Thumb cornerThumb, Cursor customizedCursor)
        {
            Path adornered = AdornedElement as Path;
            if (cornerThumb != null) return;
            cornerThumb = new Thumb();
            // Set some arbitrary visual characteristics.
            cornerThumb.Cursor = customizedCursor;
            cornerThumb.Height = cornerThumb.Width = 10;
            cornerThumb.Opacity = 1;
            cornerThumb.Background = new SolidColorBrush(Colors.Black);
            visualChildren.Add(cornerThumb);
        }
        // UnScale Adorners. this part is optional
        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            if (this.visualChildren != null)
            {
                foreach (var thumb in this.visualChildren.OfType<Thumb>())
                {
                    thumb.RenderTransform
                        = new ScaleTransform(1 / ScaleXC, 1 / ScaleYC);
                    thumb.RenderTransformOrigin = new Point(0.5, 0.5);
                }
            }
            return base.GetDesiredTransform(transform);
        }
    }
