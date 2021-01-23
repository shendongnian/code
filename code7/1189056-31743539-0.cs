    public class HomePageActivity : FragmentActivity, Android.Support.V4.View.ViewPager.IOnPageChangeListener
    	{
    protected override void OnCreate (Bundle bundle)
    		{
    			base.OnCreate (bundle);
    
    			// Create your application here
    			SetContentView(Resource.Layout.home);
    var viewPager_up = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewPager_up);
    viewPager_up.AddOnPageChangeListener (this);
    
    }
    public void OnPageScrollStateChanged (int state)
    		{
    			Console.WriteLine ("OnPageScrollStateChanged "+" "+state);
    		}
    		public void OnPageScrolled (int position, float positionOffset, int positionOffsetPixels){
    Console.WriteLine ("OnPageScrolled "+" "+position);
    }
    
    		public void OnPageSelected (int position)
    		{
    			Console.WriteLine ("OnPageSelected"+" "+position);
    			
    
    		}
    }
