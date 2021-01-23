    public class HueWheel : Slider
    {
        static HueWheel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HueWheel), new FrameworkPropertyMetadata(typeof(HueWheel)));
        }
        private bool _isPressed = false;
        private Canvas _PART_FirstCanvas;
        private Canvas _PART_SecondCanvas;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //  Use () cast rather than the "as" operator because if the actual runtime 
            //  type can't be cast to the desired type, that'll throw an exception 
            //  rather than silently returning null. If you had cast (Ellipse)e.Source, 
            //  that would have blown up on you because you can't cast HueWheel to Ellipse. 
            //  That would have instantly shown you what was wrong. 
            //  But you won't get an exception here if GetTemplateChild() just returns null. 
            _PART_FirstCanvas = (Canvas)GetTemplateChild("PART_FirstCanvas");
            _PART_SecondCanvas = (Canvas)GetTemplateChild("PART_SecondCanvas");
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isPressed)
            {
                const double RADIUS = 150;
                //  Or _PART_SecondCanvas; whichever. 
                Point newPos = e.GetPosition(_PART_FirstCanvas);
                double angle = MyHelper.GetAngleR(newPos, RADIUS);
                //huewheel.Value = (huewheel.Maximum - huewheel.Minimum) * angle / (2 * Math.PI);
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            _isPressed = true;
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            _isPressed = false;
        }
    }
