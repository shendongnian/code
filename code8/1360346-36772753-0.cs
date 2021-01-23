    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        this.EnsureBindingContextIsSet (savedInstanceState);
        base.OnCreateView(inflater, container, savedInstanceState);
        var view = this.BindingInflate(Resource.Layout.symbol_item_view, null);
       return view;        
    }
