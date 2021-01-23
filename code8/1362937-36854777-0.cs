    public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2)
    {
        var i = Arguments.GetInt(ArgPlanetNumber);
        if (i == 0)
        {
            var rootView = p0.Inflate(Resource.Layout.HomePermainan, p1, false);
            // I just assume the button is in HomePermainan
            var button = rootView.FindViewById<Button>(Resource.Id.cobaButton);
            // Do whatever you want with this button like
            button.Click += (sender, args) => { Console.Write("Button clicked"); };
            return rootView;
        }
        else
        {
            return p0.Inflate(Resource.Layout.MyProfile, p1, false);
        }
    }
