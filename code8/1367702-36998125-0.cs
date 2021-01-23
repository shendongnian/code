    public class LaunchActivity:Activity
    {
       protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            SetContentView(Resource.Layout.zones_list);
            mBlueZone = FindViewById<LinearLayout>(Resource.Id.blueZoneLayout);
                mBlueZone.Click += (object sender, EventArgs args) =>
                    {
                        StartActivity(typeof(NotParkedActivity));
                    };
         }
                
    }
     public class NotParkedActivity :Activity
    {
       protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            SetContentView(Resource.Layout. vehicle_not_parked);
         }
     }
