    public class Behavior<T> where T : FrameworkElement
    {
        public static bool IsManipulating = false;
        protected T fe;
        private bool enable;
        public bool Enable
        {
            get
            {
                return enable;
            }
            set
            {
                bool changed = false;
                if (enable != value)
                {
                    changed = true;
                }
                enable = value;
                if (changed)
                {
                    if (enable)
                    {
                        Enable_Partial();
                    }
                    else
                    {
                        Disable_Partial();
                    }
                    
                }
                
            }
        }
      
        public Behavior(T _fe)
        {
            
            fe = _fe;
            fe.IsManipulationEnabled = true;
            enable = true;
        }
        protected virtual void Enable_Partial()
        {
        }
        protected virtual void Disable_Partial()
        {
        }
    }
    public class ClickBehavior : Behavior<FrameworkElement>
    {
        public const double MAXIMUM_TOUCH_DELTA_CHANGED = 5;
        public const double MAXIMUM_MOUSE_DELTA_CHANGED = 10;
        public const int MAXIMUM_TOUCH_DURATION = 333;
        private Position initialPosition;
        private DateTime startDate;
        public ClickBehavior(FrameworkElement _fe)
            : base(_fe)
        {
            
            fe.MouseLeftButtonDown += OnMouseLeftButtonDown;
            fe.TouchDown += OnTouchDown;
        }
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
    "Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FrameworkElement));
        // This method raises the Tap event
        private void RaiseClickEvent()
        {
           
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ClickEvent);
            fe.RaiseEvent(newEventArgs);
        }
        #region touch handle
        private void StopTouchManipulation(TouchEventArgs e)
        {
           
            initialPosition = null;
            fe.TouchUp -= OnTouchUp;
            fe.TouchLeave -= OnTouchLeave;
            MainWindow.Current.TouchMove -= OnTouchMove;
        }
        private void OnTouchDown(object sender, TouchEventArgs e)
        {
            if (Enable)
            {
               
                initialPosition = new Position(e.GetTouchPoint(MainWindow.Current));
                startDate = DateTime.Now;
                fe.TouchUp += OnTouchUp;
                fe.TouchLeave += OnTouchLeave;
                MainWindow.Current.TouchMove += OnTouchMove;
            }
            
        }
        private void OnTouchUp(object sender, TouchEventArgs e)
        {
            
            TouchPoint tp = e.GetTouchPoint(fe);
            Rect bounds = new Rect(new Point(0, 0), fe.RenderSize);
            if (bounds.Contains(tp.Position))
            {
                if ((DateTime.Now - startDate).TotalMilliseconds < MAXIMUM_TOUCH_DURATION)
                {
                    e.Handled = true;
                    RaiseClickEvent();
                }
            }
            StopTouchManipulation(e);
        }
        private void OnTouchLeave(object sender, TouchEventArgs e)
        {
           
            StopTouchManipulation(e);
        }
        private void OnTouchMove(object sender, TouchEventArgs e)
        {
            Position pos = new Position(e.GetTouchPoint(MainWindow.Current));
            double distance = Position.GetDistance(initialPosition, pos);
            if (distance >= MAXIMUM_TOUCH_DELTA_CHANGED)
            {
                StopTouchManipulation(e);
            }
        }
        #endregion
        #region mouse handle
        private void StopClickManipulation()
        {
            initialPosition = null;
            fe.MouseLeftButtonUp -= OnMouseLeftButtonUp;
            fe.MouseLeave -= OnMouseLeave;
            MainWindow.Current.MouseMove -= OnMouseMove;
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Enable)
            {
                initialPosition = new Position(Mouse.GetPosition(MainWindow.Current));
                fe.MouseLeftButtonUp += OnMouseLeftButtonUp;
                fe.MouseLeave += OnMouseLeave;
                MainWindow.Current.MouseMove += OnMouseMove;
            }
            
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            RaiseClickEvent();
            StopClickManipulation();
        }
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            StopClickManipulation();
        }
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            StopClickManipulation();
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Position pos = new Position(Mouse.GetPosition(MainWindow.Current));
            double distance = Position.GetDistance(initialPosition, pos);
            if (distance >= MAXIMUM_MOUSE_DELTA_CHANGED)
            {
                StopClickManipulation();
            }
        }
        #endregion
    }
