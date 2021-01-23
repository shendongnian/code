        base.OnCreate(bundle);
        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.Main);
        string url = "http://192.168.90.102/test_api/handler.php/";
        Online[] onlines = CallRestService(url);
        LinearLayout layoutBase = FindViewById<LinearLayout>(Resource.Id.linearOnlineOffers);
        foreach (Online online in onlines)
        {
            ImageView img = new ImageView(this);
            img.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            img.SetScaleType(ImageView.ScaleType.CenterCrop);
            img.Visibility = ViewStates.Visible;
            layoutBase.AddView(img);
            Koush.UrlImageViewHelper.SetUrlDrawable(img, online.picture_filename);
        }
    }
