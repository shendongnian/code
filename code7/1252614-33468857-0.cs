    namespace MurakamiKiev
    {
        [Activity(Label = "Murakami",  Icon = "@drawable/logo", Theme = "@android:style/Theme.Black.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
        public class CartActivity : Activity
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.YourLayout);
            }
        }
    }
