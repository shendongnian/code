    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    { 
       var ignored = base.OnCreateView(inflater, container, savedInstanceState);
       var view = this.BindingInflate(Resource.Layout.MainView, null);
       HasOptionsMenu = true;
       var cardRecyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.myRecyclerView);
       if (cardRecyclerView != null)
       {
           cardRecyclerView.HasFixedSize = false;
           var layoutManager = new LinearLayoutManager(Activity);
           cardRecyclerView.SetLayoutManager(layoutManager);
        }
    
        return view;
    }
