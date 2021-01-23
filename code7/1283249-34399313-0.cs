    public class NotifyEllipse : Shape
    {
        static NotifyEllipse()
        {
            FillProperty.AddOwner(typeof(NotifyEllipse), new FrameworkPropertyMetadata(
                (o, e) =>
                {
                    if (e.NewValue != e.OldValue)
                    {
                        ((NotifyEllipse)o).RaiseEvent(new RoutedEventArgs(FillChangedEvent));
                    }
                }));
        }
        public static readonly RoutedEvent FillChangedEvent =
            EventManager.RegisterRoutedEvent(
                "FillChanged", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(NotifyEllipse));
        public event RoutedEventHandler FillChanged
        {
            add { AddHandler(FillChangedEvent, value); }
            remove { RemoveHandler(FillChangedEvent, value); }
        }
        protected override Geometry DefiningGeometry
        {
            get { return new EllipseGeometry(new Rect(RenderSize)); }
        }
    }
