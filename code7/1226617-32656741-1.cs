    public class DoubleTappableView : View
    {
        private readonly GestureDetector _gestureDetector;
    
        public DoubleTappableView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            _gestureDetector = new GestureDetector(context, new GestureListener());
        }
    
        public override bool OnTouchEvent(MotionEvent e)
        {
            return _gestureDetector.OnTouchEvent(e);
        }
    
        private class GestureListener : GestureDetector.SimpleOnGestureListener
        {
            public override bool OnDown(MotionEvent e)
            {
                return true;
            }
            public override bool OnDoubleTap(MotionEvent e)
            {
                //TODO: Add double tap logic here
                return true;
            }
        }
    }
