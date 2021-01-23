    private class GestureListener : GestureDetector.SimpleOnGestureListener
		{
			public override bool OnDown(MotionEvent e)
			{
				return true;
			}
			public override bool OnDoubleTap(MotionEvent e)
			{
				return true;
			}
		}
