    [Activity]
    public class clsExitActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Finish();
        }
        public static void ExitApp(Context ctx)
        {
            var i = new Intent(ctx, typeof(clsExitActivity));
            i.AddFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask | ActivityFlags.ExcludeFromRecents | ActivityFlags.NoAnimation);
            ctx.StartActivity(i);
        }
    }
