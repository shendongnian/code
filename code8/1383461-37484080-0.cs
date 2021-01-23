    public class SamplePagerAdapter : FragmentPagerAdapter
    {
        private MainActivity _activity;
        CustomViewPager _pager;
        private List<Android.Support.V4.App.Fragment> _fragments;
        Android.Support.V4.App.FragmentManager _fragmentManager;
        public MenuPagerAdapter(Android.Support.V4.App.FragmentManager fm, MainActivity activity, CustomViewPager pager)
            : base(fm)
        {
            _fragments = new List<Android.Support.V4.App.Fragment>();
            _fragments.Add(new HomeFragment());
            _fragments.Add(new SurfboardKopenFragment());
            _fragments.Add(new NieuwsbriefFragment());
            _fragments.Add(new ContactFragment()); // and etc.
            _fragmentManager = fm;
            _activity = activity;
            _pager = pager;
        }
        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return _fragments[position];
        }
        private string FormatTitle(string title)
        {
            return System.String.Join(System.Environment.NewLine, title.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
        public override int Count
        {
            get { return 6; } // amount of fragments you have.
        }
        public override int GetItemPosition(Java.Lang.Object objectValue)
        {
            return PositionNone;
        }
        public Android.Support.V4.App.Fragment GetFragment(int position)
        {
            return  _fragments[position];
        }
    }
