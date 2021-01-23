    public class MyFragment : Android.Support.V4.App.ListFragment 
    {
        string[] animals = new string[5] { "Tiger", "Lion", "Zebra", "Cheetah", "Giraffe" };
        CustomViewPager vpager;
        Context thiscontext;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            thiscontext = container.Context;
            var view = inflater.Inflate(Resource.Layout.Main, container, true);
            var vp = view.FindViewById<CustomViewPager>(Resource.Id.ViewPager);
            vpager = vp;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            this.ListAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleExpandableListItem1, animals);
        }
        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            // We can display everything in place with fragments.
            // Have the list highlight this item and show the data.
            ListView.SetItemChecked(position, true);
           // vpager.SetOnPageChangeListener(new PagerListener());
            vpager.SetCurrentItem(1, true);
        }
  
    }
