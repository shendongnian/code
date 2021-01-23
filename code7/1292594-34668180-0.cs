    internal class test
    {
    	private SimpleOnGestureListener longClickListener = new SimpleOnGestureListenerAnonymousInnerClassHelper();
    
    	private class SimpleOnGestureListenerAnonymousInnerClassHelper : GestureDetector.SimpleOnGestureListener
    	{
    		public SimpleOnGestureListenerAnonymousInnerClassHelper()
    		{
    		}
    
    		public virtual void onLongPress(MotionEvent e)
    		{
    			hasPerformedLongPress = childView.performLongClick();
    			if (hasPerformedLongPress)
    			{
    				if (rippleHover)
    				{
    					startRipple(null);
    				}
    				cancelPressedEvent();
    			}
    		}
    
    		public override bool onDown(MotionEvent e)
    		{
    			hasPerformedLongPress = false;
    			return base.onDown(e);
    		}
    	}
    }
