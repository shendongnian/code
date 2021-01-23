    public class MyFragment : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            this.EnsureBindingContextIsSet(savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.YOUR_VIEW, container, false);
            var searchField = view.FindViewById<T>(Resource.Id.RESOURCE_ID);
            return view;
        }
    }
