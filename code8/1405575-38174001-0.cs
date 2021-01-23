    public class Activity1 : AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
	        var g = new Game1();
	        SetContentView((View)g.Services.GetService(typeof(View)));
	        g.Run();
        }
    }
