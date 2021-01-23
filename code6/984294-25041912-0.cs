    public class SecondPage : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            var reg = this.Intent.Extras.GetString("reg");
