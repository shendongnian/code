    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(Resource.Layout.Example_Fragment, container, false);
        var button = view.FindViewById<Button>(Resource.Id.cobaButton);
    }
