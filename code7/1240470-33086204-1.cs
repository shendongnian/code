    public class Test : Activity, View.IOnTouchListener
    {
            private GestureDetector _gestureDetector = null;
    
    
            protected override void OnCreate (Bundle bundle)
            {
        
                _gestureDetector = new GestureDetector(new MyDoubleTapListener (this));
    
          
            _editText.SetOnTouchListener(this);
            }
    
       
            public bool OnTouch(View v, MotionEvent e)
            {    
                return _gestureDetector.OnTouchEvent(e);
            }
    
    
    }
