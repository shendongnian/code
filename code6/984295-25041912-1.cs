    public class SecondPage : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            var reg = this.Intent.Extras.GetString("reg");
            SetContentView(Resource.Layout.second_layout);
            var textView = this.FindViewById<TextView>(Resource.Id.secondText);
            textView.Text = reg;
