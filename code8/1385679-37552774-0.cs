    class ViewPagerAdapter : FragmentPagerAdapter
    {
        private List<Android.Support.V4.App.Fragment> mFragmentList = new List<Android.Support.V4.App.Fragment>();
        private List<string> mFragmentTitleList = new List<string>();
    
        public ViewPagerAdapter(Android.Support.V4.App.FragmentManager manager)
            : base(manager)
        {
    
        }
    
        public override int Count
        {
            get
            {
                return mFragmentList.Count;
            }
        }
        public override Android.Support.V4.App.Fragment GetItem(int postion)
        {
            return mFragmentList[postion];
        }
    
        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(mFragmentTitleList[position]);
        }
    
        public void AddFragment(Android.Support.V4.App.Fragment fragment, string title)
        {
            mFragmentList.Add(fragment);
            mFragmentTitleList.Add(title);
        }
    }
