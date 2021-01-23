    public partial class PaintDrawingControl : UserControl
    {
        public string TextToDraw { get; set; }
        // You do not need the define a Font property.
        // As it is already defined in 'Control' class
        // UserControl -> ContainerControl -> ScrollableControl -> Control
        //  Here comes the rest.
    }
