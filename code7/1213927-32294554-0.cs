        internal static void Init(Control control, Control container)
        {
            _moving = false;
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;
            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;
            WorkType = MoveOrResize.MoveAndResize;
            control.MouseDown += (sender, e) => StartMovingOrResizing(control, e);
            control.MouseUp += (sender, e) => StopDragOrResizing(control);
            //control.MouseMove += (sender, e) => MoveControl(container, e); // wrong!!
            control.MouseMove += (sender, e) => MoveControl(control, e);     // right!
        }
