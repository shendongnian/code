    [Activity]
    public class MainActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            SetContentView(Resource.Layout.activity_main);
    
            // Initialize Acr UserDialogs
            UserDialogs.Init(this);
        }
    }
