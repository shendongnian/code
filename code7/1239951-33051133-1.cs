    public class MainActivity : Activity, GestureDetector.IOnGestureListener
	{
    private GestureDetector _gestureDetector;
    public bool OnDown(MotionEvent e)
		{
			return false;
		}
		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			bool result = false;
			int SWIPE_THRESHOLD = 80;
			int SWIPE_VELOCITY_THRESHOLD = 80;
			try
			{
				float diffY = e2.GetY() - e1.GetY();
				float diffX = e2.GetX() - e1.GetX();
				if (Math.Abs(diffX) > Math.Abs(diffY))
				{
					if (Math.Abs(diffX) > SWIPE_THRESHOLD && Math.Abs(velocityX) > SWIPE_VELOCITY_THRESHOLD)
					{
						if (diffX > 0)
						{
							//code for swipe right here
							
						}
						else
						{
							//code for swipe Left here
							
						}
					}
				}
			}
			catch (Exception exception)
			{
				//exception.printStackTrace();
			}
			return result;
		}
		public void OnLongPress(MotionEvent e) {}
		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return false;
		}
		public void OnShowPress(MotionEvent e) {}
		public bool OnSingleTapUp(MotionEvent e)
		{
			return false;
		}
    public override bool OnTouchEvent(MotionEvent e)
		{
			_gestureDetector.OnTouchEvent(e);
			return false;
		}
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			_gestureDetector = new GestureDetector(this);
			
		}
    }
