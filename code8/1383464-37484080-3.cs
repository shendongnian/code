    public class SamplePagerAdapter : FragmentPagerAdapter
    {
        private string[] Titles;
        private List<Android.Support.V4.App.Fragment> _fragments;
        Android.Support.V4.App.FragmentManager _fragmentManager;
        public MenuPagerAdapter(Android.Support.V4.App.FragmentManager fm, string[] titles)
            : base(fm)
        {
            Titles = titles;
            _fragments = new List<Android.Support.V4.App.Fragment>();
            _fragments.Add(new HomeFragment());
            _fragments.Add(new SurfboardKopenFragment());
            _fragments.Add(new NieuwsbriefFragment());
            _fragments.Add(new ContactFragment()); // and etc.
        }
        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return _fragments[position];
        }
        public override ICharSequence GetPageTitleFormatted(int position)
        {
               
           return new Java.Lang.String(Titles[position]);
        }
        public override int Count
        {
            get { Titles.Length; } // amount of fragments you have = Amount of Tab titles.
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
