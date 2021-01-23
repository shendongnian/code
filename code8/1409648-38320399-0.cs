    public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2)
        {
           AppPreferences ap = new AppPreferences(mContext);
           var i = Arguments.GetInt(ArgPlanetNumber);
           if (i == 0)
           {
             var rootView = p0.Inflate(Resource.Layout.Kategori, p1, false);
             Button btnTIM= rootView.FindViewById<Button>(Resource.Id.btnTIM);
             Button btnManShoes= rootView.FindViewById<Button>(Resource.Id.btnManShoes);
        
             btnTIM.Click += delegate
             {
                var myActivity = (MenuUtama)this.Activity;
                AndHUD.Shared.Show(myActivity, "Loading..");
                if (myActivity.isOnline() == true)
                ambilTanggalTIM(ap);
                else
                myActivity.internetDropDialog();
                    };
        
                btnManShoes.Click += delegate
                {
                  var fragment = new PlanetFragment();
                  var arguments = new Bundle();
    
                  arguments.PutInt(PlanetFragment.ArgPlanetNumber, 100);
                  fragment.Arguments = arguments;
    
                  FragmentManager.BeginTransaction()
                  .Replace(Resource.Id.content_frame, fragment)
                  .Commit();
                };
            }
           else if(i == 10)
           {
             var rootView = p0.Inflate(Resource.Layout.Example, p1, false);
             return rootView;
           }
           else if(i == 100)
           {
             var rootView = p0.Inflate(Resource.Layout.ManShoes, p1, false);
             return rootView;
           }
        
          return rootView;
        }
