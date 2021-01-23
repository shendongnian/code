    public class YourFragment : Fragment, View.IOnTouchListener, GestureDetector.IOnGestureListener
    {
        private GestureDetector _gestureDetector;
        private ImageView imageView;
        public YourFragment()
        {
            this.RetainInstance = true;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_profile, null);
             imageView = view.FindViewById<ImageView>(Resource.Id.profile_image);
            _gestureDetector = new GestureDetector(this);
            imageView.SetOnTouchListener(this);
            return view;
        }
        
        public bool OnTouch(View v, MotionEvent e)
        {
            return _gestureDetector.OnTouchEvent(e);
        }
        public bool OnDown(MotionEvent e)
        {
            //rzee: Changed to true
            return true;
        }
        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            throw new System.NotImplementedException();
        }
        public void OnLongPress(MotionEvent e)
        {
            
        }
        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            //rzee: Changed to true
            return true;
        }
        public void OnShowPress(MotionEvent e)
        {
        }
        public bool OnSingleTapUp(MotionEvent e)
        {
            return true;
        }
    }
    
