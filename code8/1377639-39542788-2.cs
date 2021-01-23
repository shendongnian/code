    public class AdornerSpell : Adorner
    {
        public Rect drawLocation { get; set; }
        public AdornerSpell(UIElement adornedElement) : base(adornedElement) { }
        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            drawingContext.DrawLine(new System.Windows.Media.Pen(new SolidColorBrush(Colors.Red), 1), drawLocation.BottomLeft, drawLocation.BottomRight);
        }
    }
