    namespace MovieHall.Client.Android.Views.Fragments
    {    
        [Register("moviehall.client.android.views.fragments.AllMoviesView")]
        public class AllMoviesView : MvxFragment
        {
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                var ignore =  base.OnCreateView(inflater, container, savedInstanceState);
                return this.BindingInflate(Resource.Layout.all_movies, null);
            }
        }
    }
