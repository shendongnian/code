    public class VisualHost : UIElement
    {
        public Visual Visual { get; set; }
        protected override int VisualChildrenCount
        {
            get { return Visual != null ? 1 : 0; }
        }
        protected override Visual GetVisualChild(int index)
        {
            return Visual;
        }
    }
