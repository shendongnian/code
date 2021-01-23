     [Activity(Label = "ViewPagerIndicator", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
     public class MainActivity : AppCompatActivity
     {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "ViewPager Indicator Dots";
            var pager = new ViewPagerAdapter(SupportFragmentManager);
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.Adapter = pager;
            viewPager.PageSelected += ViewPager_PageSelected;
        }
        private void ViewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            var viewPagerDotsLayout = FindViewById<LinearLayout>(Resource.Id.viewPagerCountDots);
            for (int i = 0; i < viewPagerDotsLayout.ChildCount; i++)
            {
                ImageView dotImage = (ImageView)viewPagerDotsLayout.GetChildAt(i);
                if (i == e.Position)
                    dotImage.SetImageResource(Resource.Drawable.ViewPagerDotSelected);
                else
                    dotImage.SetImageResource(Resource.Drawable.ViewPagerDotUnselected);
            } 
        }
    }
    
    public class ViewPagerAdapter : FragmentStatePagerAdapter
    {
        int numberOfFragments = 3;
        public ViewPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
        {
        }
        public override int Count
        {
            get
            {
                return numberOfFragments;
            }
        }
        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new Fragment1();
                case 1:
                    return new Fragment2();
                case 2:
                    return new Fragment3();
                default: return new Fragment1();
            }
        }
    }
